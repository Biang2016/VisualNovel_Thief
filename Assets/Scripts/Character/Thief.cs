using UnityEngine;

public class Thief : MonoBehaviour
{
    public float speed = 6.0F;
    private Vector2 moveDirection = Vector2.zero;
    public Animator Animator;
    public Rigidbody2D Rigidbody2D;

    void Start()
    {
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        moveDirection = new Vector2(hor, ver);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        Rigidbody2D.velocity= moveDirection;
        Animator.SetBool("LeftRun", hor < 0);
        Animator.SetBool("RightRun", hor > 0);
    }
}