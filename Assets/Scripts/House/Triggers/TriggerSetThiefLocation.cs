using UnityEngine;

public class TriggerSetThiefLocation : TriggerBase
{
    [SerializeField] private People Owner;

    protected override void OnChildTriggerEnter2D()
    {
        Owner.ThiefInMyRoom = true;
    }

    protected override void OnChildTriggerExit2D()
    {
        Owner.ThiefInMyRoom = false;
    }
}