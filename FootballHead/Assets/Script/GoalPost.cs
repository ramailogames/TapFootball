using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    bool isTocuhed = false;

    public enum PlayerType 
    {
        Cpu, Player
    }

    public PlayerType playerType;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (isTocuhed)
            {
                return;
            }

            isTocuhed = true;
            AudioManagerCS.instance.Play("goal");
            AddScore();
            collision.GetComponent<BallScript>().SpawnGoalVfx();
            Destroy(collision.gameObject);
            FindObjectOfType<BallSpawner>().SpawnBall();
            Invoke("ResetTouch", .6f);
        }
    }

    void ResetTouch()
    {
        isTocuhed = false;
    }


    void AddScore()
    {
        switch (playerType)
        {
            case PlayerType.Player:
            {
                    FindObjectOfType<RamailoGamesScoreManager>().AddScore(1f);
                    FindObjectOfType<DanceGirl>().Dance();
                    
               break;
            }

            case PlayerType.Cpu:
            {
                    FindObjectOfType<BotScoreManager>().AddBotScore(1f);
                    FindObjectOfType<DanceGirl>().Dance();
                    break;
            }
        }
    }
}
