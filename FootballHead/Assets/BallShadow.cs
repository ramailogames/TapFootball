using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShadow : MonoBehaviour
{

    BallScript ball;
    [SerializeField] GameObject shadowGfx;
    // Update is called once per frame
    void Update()
    {
        CheckBall();
    }

    void CheckBall()
    {
        if(ball != null)
        {
            FollowBall();
            shadowGfx.SetActive(true);
            return;
        }

        ball = FindObjectOfType<BallScript>();
        shadowGfx.SetActive(false);

    }

    void FollowBall()
    {
        Vector2 tempPos = ball.transform.position;
        tempPos.y = transform.position.y;
        transform.position = tempPos;

    }
}
