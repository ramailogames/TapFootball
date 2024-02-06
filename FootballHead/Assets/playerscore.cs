using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerscore : MonoBehaviour
{
    public TextMeshProUGUI playerScoreTxt;
    public float playerScore = 0;

    private void Start()
    {
        playerScoreTxt.text = playerScore.ToString();
    }

    public void AddScore()
    {

        playerScore++;
        playerScoreTxt.text = playerScore.ToString();

    }
}
