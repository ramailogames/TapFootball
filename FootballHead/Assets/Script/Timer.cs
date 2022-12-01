using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [HideInInspector]public float playedTimer = 0;

    private void OnEnable()
    {
        playedTimer = 0;
    }
    private void Update()
    {
        playedTimer += Time.deltaTime;
    }

}
