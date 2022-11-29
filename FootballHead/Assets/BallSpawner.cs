using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform ballSpawnPos;

    private void Start()
    {
        SpawnBall();
    }
    public void SpawnBall()
    {
        StartCoroutine(EnumSpawnBall());
    }

    public IEnumerator EnumSpawnBall()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(ballPrefab, ballSpawnPos.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
    }

}
