using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvements : MonoBehaviour
{
    public Rigidbody2D rb;
    // Store player's direction
    public float moveDirectionX = 0;

    public float moveSpeed = 10;

    public float jumpForce = 7;

    public int nbMaxJumpsAllowed = 2;

    public int currentNumberOfJumps = 0;

    public Transform groundCheck;

    public float groundCheckRadius = 0.2f;

    public bool isOnGround = true;

    public LayerMask listGroundLayers;

    public bool isFacingRight = true;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirectionX = Input.GetAxisRaw("Horizontal");

        if(
            Input.GetButtonDown("Jump") &&
            currentNumberOfJumps < nbMaxJumpsAllowed
            ) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            currentNumberOfJumps +=1;
        }

        if(!Input.GetButton("Jump") && isOnGround) {
            currentNumberOfJumps = 0;
        }

        Flip();
        animator.SetFloat("VelocityX", rb.velocity.x);
    }

    private void Flip() {
        if(
            (moveDirectionX > 0 && !isFacingRight) ||
            (moveDirectionX < 0 && isFacingRight)
        ) {
            transform.Rotate(0, 180, 0);
            isFacingRight = !isFacingRight;
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(moveDirectionX * moveSpeed,
        rb.velocity.y
        ); 
        isOnGround = IsGrounded();
    }

    public bool IsGrounded() {
        return Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            listGroundLayers
        );
        
    }

    private void OnDrawGizmos() {
        if(groundCheck != null) {
            Gizmos.color = Color.green; 
            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundCheckRadius
            );
        }
    }
}
