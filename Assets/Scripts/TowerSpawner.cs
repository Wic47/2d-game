using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;
using System;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using System.Linq;


public class TowerSpawner : MonoBehaviour
{
    private GameObject panel;
    private int towerPos = 0;


    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("ui");
        panel.SetActive(false);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Menu();
        }
    }

    void Menu()
    {
        int layerMask = 1 << 8;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(pos, new Vector2(0, 0), 0.01f, layerMask);

        if (hits.Length > 0)
        {
            if (hits[0].collider.tag != "ui")
            {
                panel.transform.position = hits[0].transform.position + new Vector3(0, 2, 10);
            }
            panel.SetActive(true);
            if (towerPos == hits[0].collider.name.Last() && panel.activeSelf)
            {
                panel.SetActive(false);
            }
            towerPos = (int)Char.GetNumericValue(hits[0].collider.name.Last());
        }
        else
        {
            panel.SetActive(false);
        }
    }
    public void SpawnTower()
    {
        
        panel.SetActive(false);
    }

}
