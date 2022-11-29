using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    bool isTocuhed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (isTocuhed)
            {
                return;
            }

            isTocuhed = true;
            Destroy(collision.gameObject);
            FindObjectOfType<BallSpawner>().SpawnBall();
            Invoke("ResetTouch", .6f);
        }
    }

    void ResetTouch()
    {
        isTocuhed = false;
    }
}
