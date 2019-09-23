using UnityEngine;

public class FreeFallDownArea : TriggerBase
{
    private float time = 0;
    private float exitTime = 0;

    protected override void OnChildTriggerEnter2D()
    {
        Manager.Instance.Thief.Rigidbody2D.gravityScale = 1000;
        Manager.Instance.Thief.Flying = true;
        if (exitTime > 0.5f)
        {
            AudioManager.Instance.SoundPlay("UmbrellaOpen", true);
        }

        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        exitTime += Time.deltaTime;
    }

    protected override void OnChildTriggerExit2D()
    {
        Manager.Instance.Thief.Rigidbody2D.gravityScale = 0;
        Manager.Instance.Thief.Flying = false;
        exitTime = 0;
        if (time > 0.5f)
        {
            AudioManager.Instance.SoundPlay("FallDownHit", true);
            AudioManager.Instance.SoundPlay("Brick", true);
        }
    }
}