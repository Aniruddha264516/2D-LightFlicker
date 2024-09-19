using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;  
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float coyoteTimeDuration;
    [SerializeField] private int maxJumps = 2; 

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float coyoteTimeCounter;
    private int jumpsLeft;  

    private void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        jumpsLeft = maxJumps;  
    }

    private void Update()
    {
        
        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTimeDuration; // 0.25
            jumpsLeft = maxJumps;  // 2
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Handle jump input
        if (Input.GetKeyDown(KeyCode.Space) && (coyoteTimeCounter > 0 || jumpsLeft > 0))
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);



        anim.SetBool("Grounded", isGrounded());
    }

    private void Jump()
    {
        // Perform the jump
        body.velocity = new Vector2(body.velocity.x, jumpForce); // jumpforce = 10
        anim.SetTrigger("Jump");
        jumpsLeft--;  
        coyoteTimeCounter = 0f;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
