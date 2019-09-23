using UnityEngine;

public abstract class TriggerBase : MonoBehaviour
{
    private static int Layer_Player;

    private void Awake()
    {
        Layer_Player = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == Layer_Player)
        {
            OnChildTriggerEnter2D();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == Layer_Player)
        {
            OnChildTriggerExit2D();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == Layer_Player)
        {
            OnChildCollisionEnter2D();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == Layer_Player)
        {
            OnChildCollisionExit2D();
        }
    }

    protected virtual void OnChildTriggerEnter2D()
    {
    }

    protected virtual void OnChildTriggerExit2D()
    {
    }

    protected virtual void OnChildCollisionEnter2D()
    {
    }

    protected virtual void OnChildCollisionExit2D()
    {
    }
}