using UnityEngine;

public class MoveTriggerController : MonoBehaviour
{
    private int Layer_Player;
    private TriggerGoToPivot TriggerGoToPivot;

    private void Awake()
    {
        Layer_Player = LayerMask.NameToLayer("Player");
        TriggerGoToPivot = GetComponent<TriggerGoToPivot>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == Layer_Player)
        {
            if (TriggerGoToPivot != null)
            {
                TriggerGoToPivot.GoToPivot();
            }
        }
    }
}