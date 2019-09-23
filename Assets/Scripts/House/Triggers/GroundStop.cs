public class GroundStop : TriggerBase
{
    protected override void OnChildTriggerEnter2D()
    {
        Manager.Instance.Thief.Rigidbody2D.gravityScale = 0;
        Manager.Instance.Thief.Flying = false;
    }
}