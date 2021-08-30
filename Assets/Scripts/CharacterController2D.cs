using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;
    public static bool isUp;
    public static bool isCrouchingL;
    public static bool isCrouchingR;

    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    Transform groundCheckL;
    [SerializeField]
    private Transform groundCheckR;

    [SerializeField]
    private float runSpeed = 6.5f;
    [SerializeField]
    float jumpSpeed = 10;

    // Start is called before the first frame update
    void Start()    
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if ((Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
           (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
           (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))) 
        {
                isGrounded = true;
        }

        else
        {
            isGrounded = false;
            animator.Play("SaraJump"); //SaraFall ???
        }

        if ((Input.GetKey("s") && Input.GetKey("a")) || (Input.GetKey("down") && Input.GetKey("left")))
        {
            rb2d.velocity = new Vector2(runSpeed * -0.5f, rb2d.velocity.y);

            if (isGrounded)
                animator.Play("SaraCrouch");
            spriteRenderer.flipX = true;
            isUp = false;
            isCrouchingL = false;
            isCrouchingR = true;
        }
        else if ((Input.GetKey("s") && Input.GetKey("d")) || (Input.GetKey("down") && Input.GetKey("right")))
        {
            rb2d.velocity = new Vector2(runSpeed * 0.5f, rb2d.velocity.y);

            if (isGrounded)
                animator.Play("SaraCrouch");
            spriteRenderer.flipX = false;
            isUp = false;
            isCrouchingL = true;
            isCrouchingR = false;
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            isUp = true;
            if (isGrounded)
            {
                animator.Play("SaraRun");
            }
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            isUp = true;
            if (isGrounded)
            {
                animator.Play("SaraRun");
            }
            spriteRenderer.flipX = true;

        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            isUp = false;
            if (isGrounded)
            {
                animator.Play("SaraSit");
            }
        }
        else
        {
            if (isGrounded)
                animator.Play("SaraIdle");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            isCrouchingL = false;
            isCrouchingR = false;
            isUp = true;
        }

        if (Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space"))
        {
            if (isGrounded)
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("SaraJump");
        }
    }
}
