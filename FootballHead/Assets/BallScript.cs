using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float kickForce;
    [SerializeField] BallGfx ballGfx;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke("StartKickOff", 1f);
    }
    public void TakeKick(int direction)
    {
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

        if (index == 1)
        {
            rb.AddForce(Vector2.right * kickForce/5);
        }

        if (index == 2)
        {
            rb.AddForce(Vector2.left * kickForce/5);
        }

        ballGfx.rotate = true;
    }


}
