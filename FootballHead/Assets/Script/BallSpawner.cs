using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform ballSpawnPos, vfxSpawnPos;
    [SerializeField] GameObject readyVfx;
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
        yield return new WaitForSeconds(2f);
        ReadyVfx();
        yield return new WaitForSeconds(1f);
        //AudioManagerCS.instance.Play("whistlewarn");
        Instantiate(ballPrefab, ballSpawnPos.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
    }


    void ReadyVfx()
    {
        Instantiate(readyVfx, vfxSpawnPos.position, Quaternion.identity);
    }
}
