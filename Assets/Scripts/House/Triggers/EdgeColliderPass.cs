using UnityEngine;

public class EdgeColliderPass : TriggerBase
{
    [SerializeField] private string BlockName;

    protected override void OnChildCollisionExit2D()
    {
        if (BlockName != "" && Manager.Instance.Flowchart.HasBlock(BlockName))
        {
            Manager.Instance.Flowchart.ExecuteBlock(BlockName);
        }
    }
}