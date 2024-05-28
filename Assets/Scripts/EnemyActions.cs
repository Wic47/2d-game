using System.Data;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 1f;
    private float attackDistance = 3f;
    private Collider2D col;
    private Collider2D col2;
    private Transform playerTransform;
    private int level;
    public int hp;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        col = GetComponent<Collider2D>();
        col2 = GameObject.Find("Player").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(col, col2);
        level = Mathf.Clamp((int)Mathf.Floor(Stats.timeAlive) / 20, 1, 100);
        hp = 20 + 5 * level;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            playerTransform.transform.position,
            speed * Time.deltaTime
        );
        transform.position += new Vector3(0, 0, 10);

        if (transform.position.x < playerTransform.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (
            Vector2.Distance(transform.position, playerTransform.transform.position)
            < attackDistance
        )
        {
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }
        if (hp <= 0)
        {
            anim.SetBool("death", true);
            Destroy(gameObject, 0.75f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<Stats>().Damage(1);
    }

    void OnDestroy()
    {
        Stats.GainXp(level);
    }
}
