using UnityEngine;

public class TriggerGoToPivot : TriggerBase
{
    [SerializeField] private Transform Pivot;

    protected override void OnChildTriggerEnter2D()
    {
        Manager.Instance.Thief.transform.position = Pivot.transform.position;
    }
}