using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Enemy;
    [SerializeField] float spawnInterval = 1f;

    private bool isSpawning = false;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            if (!isSpawning)
            {
                isSpawning = true;
                Vector3 spawnPosition = GenerateRandomSpawnPosition();
                Instantiate(Enemy, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnInterval);
                isSpawning = false;
            }
            else
            {
                yield return null;
            }
        }
    }

    Vector3 GenerateRandomSpawnPosition()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-130f, 130f);
        return new Vector3(x, .3f, z);
    }
}
