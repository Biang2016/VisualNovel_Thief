using UnityEngine;

public class TriggerSound : TriggerBase
{
    [SerializeField] private string AudioName;

    protected override void OnChildTriggerEnter2D()
    {
        AudioManager.Instance.SoundPlay(AudioName, true);
    }
}