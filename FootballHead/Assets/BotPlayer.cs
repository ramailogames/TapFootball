using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPlayer : MonoBehaviour
{
    [Header("Componenets")]
    Rigidbody2D rb;
    Animator anim;

    [Header("Ground Check")]
    public Transform checkGroundPos;
    public float checkGroundRadius;
    public LayerMask whatIsGround;
    bool isGrounded;

    [Header("Movement")]
    public int facingDir;
    public float jumpForce;

    [Header("Check Ball")]
    public Transform checkBallPos;
    public float checkBallRadius;
    public LayerMask whatIsBall;
    bool isTouchingBall;

    [Header("Check Ball In Air")]
    public Transform checkBallinAirPos;
    public float checkBallInAirRadius;
    bool isBallInAir;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckSurroundings();
        UpdateAnimation();

    }

    void CheckSurroundings()
    {
        CheckGround();
        CheckBall();
        CheckBallInAir();
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(checkGroundPos.position, checkGroundRadius, whatIsGround);
    }

    void CheckBall()
    {
        isTouchingBall = Physics2D.OverlapCircle(checkGroundPos.position, checkBallRadius, whatIsBall);

        if (isTouchingBall)
        {
            anim.SetTrigger("kick");
        }
       
    }

    void CheckBallInAir()
    {
        isBallInAir = Physics2D.OverlapCircle(checkBallinAirPos.position, checkBallInAirRadius, whatIsBall);
     
        if (isBallInAir)
        {
            Debug.Log("ball is in air");
            Jump();https://github.com/new/import
            anim.SetBool("jump", true);
           
            return;
        }

        anim.SetBool("jump", false);
    }

    void Jump()
    {
        if (!isGrounded)
        {
            return;
        }

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public void KickBall()
    {
        Collider2D isTouchingBall_ = Physics2D.OverlapCircle(checkGroundPos.position, checkBallRadius, whatIsBall);

        if(isTouchingBall_ != null)
        {
            isTouchingBall_.GetComponent<BallScript>().TakeKick(facingDir);
        }
    }

    public void ResetKickAnim()
    {
        anim.ResetTrigger("kick");
    }

    void UpdateAnimation()
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
        //check ground
        Gizmos.DrawWireSphere(checkGroundPos.position, checkGroundRadius);

        //check ball
        Gizmos.DrawWireSphere(checkBallPos.position, checkBallRadius);

        //check ball in air
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(checkBallinAirPos.position, checkBallInAirRadius);
    }
}
