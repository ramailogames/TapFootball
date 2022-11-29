using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float kickForce;
    [SerializeField] BallGfx ballGfx;
    int myFacingDir = 1;
    [SerializeField] GameObject goalVfx;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke("StartKickOff", 1f);
    }

    void Flip()
    {
        if(myFacingDir == 1)
        {
            ballGfx.transform.Rotate(0, 0, 0);
        }

        if(myFacingDir == -1)
        {
            ballGfx.transform.Rotate(0, 180f, 0);
        }
       
    }

    public void SpawnGoalVfx()
    {
        Instantiate(goalVfx, transform.position, Quaternion.identity);
    }


    public void TakeKick(int direction)
    {
        rb.velocity = Vector2.zero;

        AudioManagerCS.instance.Play("kickball");
        if(direction == 1)
        {

            //right
            int indexR = Random.Range(1, 3);

            if(indexR == 1)
            {
                rb.AddForce(Vector2.right * kickForce);
            }

            if(indexR == 2)
            {
                rb.AddForce(Vector2.right * kickForce);
                rb.AddForce(Vector2.up * kickForce/2);
            }
       

          
            return;
        }

        //left
        int indexL = Random.Range(1, 3);

        if (indexL == 1)
        {
            rb.AddForce(Vector2.left * kickForce);
        }

        if (indexL == 2)
        {
            rb.AddForce(Vector2.left * kickForce);
            rb.AddForce(Vector2.up * kickForce / 2);
        }
    }

    void StartKickOff()
    {
        int index = Random.Range(1, 3);
        Debug.Log(index);
        
        AudioManagerCS.instance.Play("whistle");
        if (index == 1)
        {
            myFacingDir = -1;
            rb.AddForce(Vector2.right * kickForce/5);
        }

        if (index == 2)
        {
            myFacingDir = 1;
            rb.AddForce(Vector2.left * kickForce/5);
        }
        Flip();
        ballGfx.rotate = true;
    }


}
