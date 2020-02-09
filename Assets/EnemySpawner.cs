using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] enemyPatterns;

    public bool spawning = true;

    void Start()
    {

        InvokeRepeating("SpawnEnemies", 2.5f, 5f);

    }






    void SpawnEnemies()
    {
        if (spawning)
        {
            int rand = Random.Range(0, enemyPatterns.Length);

            Instantiate(enemyPatterns[rand], transform.position, Quaternion.identity, transform);
        }
    }
}
