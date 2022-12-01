using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Components")]
    public Transform groundCheckPos;
    Rigidbody2D rb;
    Animator anim;
    


    [Header("Movement")]
    public int facingDir;
    [SerializeField] float jumpForce;
    bool canJump = true;
    

    [Header("Check Ground")]
    public float groundRadius;
    public LayerMask whatIsGround;
    bool isGrounded;


    [Header("Ball")]
    public float BallCheckRadius;
    public LayerMask whatIsBall;
    public Transform checkBallPos;
    

    [Header("Check Ball - Auto")]
    public Transform checkBallPosAuto;
    public float checkBallRadiusAuto;
    bool isTouchingBall;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckBall();
        CheckInput();
        CheckIfCanJump();
        CheckSurroundings();
        UpdateAnimations();
    }

    void CheckInput()
    {
        Jump();
        //KickInput();
    }
    void KickInput()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("kick");
        }
    }

    void CheckBall()
    {
        isTouchingBall = Physics2D.OverlapCircle(checkBallPosAuto.position, checkBallRadiusAuto, whatIsBall);

        if (isTouchingBall)
        {
            anim.SetTrigger("kick");
        }
    }
    public void KickBall()
    {
        //isTouchingBall = Physics2D.OverlapCircle(checkBallPos.position, BallCheckRadius, whatIsBall);

        Collider2D isTouchingBall_ = Physics2D.OverlapCircle(checkBallPos.position, BallCheckRadius, whatIsBall);

        if(isTouchingBall_ != null)
        {
            isTouchingBall_.GetComponent<BallScript>().TakeKick(facingDir, !isGrounded);
        }
    }


    public void ResetAnim()
    {
        anim.ResetTrigger("kick");
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!canJump)
            {
                return;
            }
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!canJump)
            {
                return;
            }
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPos.position, groundRadius, whatIsGround);

    }

    void CheckIfCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0)
        {
            canJump = true;
            return;
        }

        canJump = false;
    }

    private void UpdateAnimations()
    {

        if (isGrounded)
        {
            anim.SetBool("jump", false);
            return;
        }

        anim.SetBool("jump", true);
    }

    private void OnDrawGizmos()
    {
        if (isGrounded)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheckPos.position, groundRadius);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheckPos.position, groundRadius);
        }

        Gizmos.DrawWireSphere(checkBallPos.position, BallCheckRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(checkBallPosAuto.position, checkBallRadiusAuto);
    }
}
