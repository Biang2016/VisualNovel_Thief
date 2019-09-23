using UnityEngine;
using UnityEngine.Events;

public class EdgeColliderCallMethod : TriggerBase
{
    [SerializeField] private UnityEvent Event;

    protected override void OnChildCollisionExit2D()
    {
        Event?.Invoke();
    }
}