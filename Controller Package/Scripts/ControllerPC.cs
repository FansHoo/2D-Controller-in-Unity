using UnityEngine;

public class ControllerPC : MonoBehaviour
{
    [SerializeField] private float speed;

    [Space]
    [SerializeField] private bool turnJump = true;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform jumpPoint;

    private Rigidbody2D rb;
    private bool isGrounded;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Controller();
    }
    private void Update()
    {
        if (turnJump)
        {
            isGrounded = Physics2D.OverlapCircle(jumpPoint.position, 0.1f) != null;
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                JumpController();
            }
        }
    }


    private void Controller()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(h, 0) * speed * Time.fixedDeltaTime);
    }

    private void JumpController()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
