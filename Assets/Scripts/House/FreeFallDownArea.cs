using System.Collections;
using UnityEngine;

public class FreeFallDownArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Manager.Instance.Thief.Rigidbody2D.gravityScale = 500;
        Manager.Instance.Thief.Flying = true;
        Manager.Instance.Flowchart.ExecuteBlock("FallRight");
    }
}