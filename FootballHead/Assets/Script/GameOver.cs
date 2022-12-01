using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnEnable()
    {
        RamailoGamesApiHandler.SubmitScore(FindObjectOfType<Timer>().playedTimer);
    }
}
