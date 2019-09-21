using UnityEngine;

public class TriggerGoToPivot : MonoBehaviour
{
    [SerializeField] private Transform Pivot;

    public void GoToPivot()
    {
        Manager.Instance.Thief.transform.position = Pivot.transform.position;
    }
}