using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private GameObject[] spawnpoints;
    private float time = 6.0f;

    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("spawnpoint");
    }

    void FixedUpdate()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            int rand = UnityEngine.Random.Range(0, 4);
            GameObject enemy = Instantiate(
                prefab,
                spawnpoints[rand].transform.position,
                Quaternion.identity
            );
            enemy.transform.parent = gameObject.transform;
            time = 8.0f;
        }
    }
}
