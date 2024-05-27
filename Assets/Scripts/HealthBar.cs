using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;

    [SerializeField]
    private TMP_Text hpText;
    public int hp = 100;
    public int maxHp = 100;

    [SerializeField]
    public TMP_Text scoreText;
    private int score = 0;

    public void Damage(int damage)
    {
        hp -= damage;
        hp = Mathf.Clamp(hp, 0, maxHp);
        healthBar.fillAmount -= damage / 100.0f;
        hpText.text = "Health: " + hp;
    }

    public void Score()
    {
        score += 1;
        scoreText.text = "Score: " + score;
        Debug.Log(score);
    }

    private void Update()
    {
        if (hp == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
