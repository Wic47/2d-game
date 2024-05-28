using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;

    [SerializeField]
    private TMP_Text hpText;

    [SerializeField]
    private Image xpBar;
    private static Image xpBar2;

    [SerializeField]
    private TMP_Text levelText;
    public int hp = 100;
    public int maxHp = 100;
    public float attackSpeed = 1;

    [SerializeField]
    public TMP_Text timeText;

    public int level;

    public static float currentXp;

    [SerializeField]
    private static float requiredXp;
    public static float timeAlive;
    private GameObject upgrades;

    void Start()
    {
        xpBar2 = xpBar;
        xpBar2.fillAmount = 0;
        requiredXp = NewRequiredXp();
        upgrades = GameObject.Find("Upgrade Container");
        upgrades.SetActive(false);
    }

    private void Update()
    {
        IncrementTime();
        if (hp == 0)
        {
            SceneManager.LoadScene(1);
        }
        if (currentXp >= requiredXp)
        {
            LevelUp();
        }
        print(currentXp);
    }

    public void Damage(int damage)
    {
        hp -= damage;
        hp = Mathf.Clamp(hp, 0, maxHp);
        healthBar.fillAmount -= (float)damage / maxHp;
        hpText.text = "Health: " + hp;
    }

    public void IncrementTime()
    {
        timeAlive += Time.deltaTime;
        timeText.text = "Time: " + Mathf.Floor(timeAlive) + "s";
    }

    public static void GainXp(int enemyLevel)
    {
        currentXp += 10 * enemyLevel;
        xpBar2.fillAmount = currentXp / requiredXp;
    }

    private void LevelUp()
    {
        level++;
        currentXp = Mathf.RoundToInt(currentXp - requiredXp);
        requiredXp = NewRequiredXp();
        xpBar2.fillAmount = currentXp / requiredXp;
        levelText.text = "Level: " + level;
        upgrades.SetActive(true);
        hp += 20;
        hp = Mathf.Clamp(hp, 0, maxHp);
        Time.timeScale = 0;
    }

    private int NewRequiredXp()
    {
        int newRequiredXp = 0;
        for (int i = 1; i <= level; i++)
        {
            newRequiredXp += (int)math.floor(i + 300 * Mathf.Pow(2, i / 7));
        }
        return newRequiredXp / 4;
    }

    public void Upgrade1()
    {
        PlayerActions.movementSpeed += 1;
        UnPause();
    }

    public void Upgrade2()
    {
        PlayerActions.damage += 3;
        UnPause();
    }

    public void Upgrade3()
    {
        attackSpeed += 0.05f;
        PlayerActions.anim.SetFloat("speed", attackSpeed);
        UnPause();
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        upgrades.SetActive(false);
    }
}
