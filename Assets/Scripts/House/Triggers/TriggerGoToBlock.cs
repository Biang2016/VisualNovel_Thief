using UnityEngine;

public class TriggerGoToBlock : TriggerBase
{
    [SerializeField] private string BlockName;

    protected override void OnChildTriggerEnter2D()
    {
        if (BlockName != "" && Manager.Instance.Flowchart.HasBlock(BlockName))
        {
            Manager.Instance.Flowchart.ExecuteBlock(BlockName);
        }
    }
}