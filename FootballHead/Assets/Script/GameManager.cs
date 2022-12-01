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
    [HideInInspector]public bool gameOver = false;
    [SerializeField] GameObject gameoverView;
    [SerializeField] TextMeshProUGUI timerText;
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
        timerText.text = currentTime.ToString("0") + "s";
        if(currentTime<= 0)
        {
            gameOver = true;
            Gameover();

        }
    }

    public void Gameover()
    {
        gameoverView.SetActive(true);
        Destroy(FindObjectOfType<BallScript>().gameObject);
    }



}
