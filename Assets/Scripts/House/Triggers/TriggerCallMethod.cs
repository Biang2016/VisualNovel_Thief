using UnityEngine;
using UnityEngine.Events;

public class TriggerCallMethod : TriggerBase
{
    [SerializeField] private UnityEvent Event;

    protected override void OnChildTriggerEnter2D()
    {
        Event?.Invoke();
    }
}