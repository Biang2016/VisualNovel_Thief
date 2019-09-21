using UnityEngine;

public class GroundStop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Manager.Instance.Thief.Rigidbody2D.gravityScale = 0;
        Manager.Instance.Thief.Flying = false;
    }
}