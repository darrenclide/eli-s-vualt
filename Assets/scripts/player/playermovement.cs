using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    float floatValue = 4f;
    public Animator animator;
    Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private bool isAttacking;
    private int force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FaceCursorDirection();
        Movement();
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("attack");
        }
        if(Input.GetKey("left shift") == true)
        {
            floatValue = 8f;
            force = 300;
        }
        else
        {
            floatValue = 4f;
            force = 200;
        }
        
        if (Input.GetKey("a") == true)
        {
            animator.SetBool("walk", true);
            rb.velocity = new Vector2(-floatValue,rb.velocity.y);
        }
        else if (Input.GetKey("d") == true)
        {
            animator.SetBool("walk", true);
            rb.velocity = new Vector2(floatValue,rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f,rb.velocity.y);
            animator.SetBool("walk", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) == true && isTouchingGround)
        {
            rb.AddForce(new Vector3(0, force, 0), ForceMode2D.Impulse);
            animator.SetBool("hop", true);
        }
        else
        {
            animator.SetBool("hop", false);
        }
    }
        void FaceCursorDirection()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x < transform.position.x)
        {
            // If the cursor is to the left of the player, flip it to face left
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            // If the cursor is to the right of the player, flip it to face right
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
