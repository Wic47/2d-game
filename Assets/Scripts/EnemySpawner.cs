using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    private GameObject spawnPos;
    private GameObject spawner;
    public static float hp = 20f;
    public static float wave = 1f;
    private Button button;

    [SerializeField] private GameObject prefab;

    private void Start()
    {
        spawner = GameObject.Find("Enemies");
        spawnPos = GameObject.Find("Waypoint 1");
        button = GameObject.Find("Next Round").GetComponent<Button>();
        
    }

    void Update()
    {
    }

    public void NextWave()
    {
        GameObject enemy = Instantiate(prefab, spawnPos.transform.position, Quaternion.identity);
        enemy.transform.parent = spawner.transform;
        button.interactable = false;
    }
}