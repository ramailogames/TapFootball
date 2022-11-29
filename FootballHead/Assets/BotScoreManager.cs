using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BotScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI botScoreTxt;

    float botScore = 0;
    public void AddBotScore(float amount)
    {
        botScore += amount;

        botScoreTxt.text = botScore.ToString();
    }
}
