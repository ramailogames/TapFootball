using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform playerGoalTarget;


    public float maxTime;
    float currentTime;
    public bool gameOver = false;
    [SerializeField] GameObject gameoverView;
    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        currentTime = maxTime;
    }

    private void Update()
    {
        ReduceTime();
    }

    void ReduceTime()
    {
        if (gameOver)
        {
            return;
        }

        currentTime -= Time.deltaTime;

        if(currentTime<= 0)
        {
            gameOver = true;
            Gameover();

        }
    }

    public void Gameover()
    {
        gameoverView.SetActive(true);
    }



}
