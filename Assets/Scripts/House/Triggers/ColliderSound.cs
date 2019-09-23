using UnityEngine;

public class ColliderSound : TriggerBase
{
    [SerializeField] private string AudioName;

    protected override void OnChildCollisionEnter2D()
    {
        AudioManager.Instance.SoundPlay(AudioName, true);
    }
}