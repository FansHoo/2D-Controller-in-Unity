using UnityEngine;

public class MobileController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction = 0;

    [Space]
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform jumpPoint;
    private Rigidbody2D rb;
    private bool isGrounded;

    private void FixedUpdate()
    {
        transform.Translate(new Vector2(direction, 0) * speed * Time.fixedDeltaTime);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(jumpPoint.position, 0.1f) != null;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }



    public void MoveLeft()
    {
        direction = -1;
    }

    public void MoveRight()
    {
        direction = 1;
    }

    public void StopMoving()
    {
        direction = 0;
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}