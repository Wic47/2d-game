using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovent : MonoBehaviour
{
    private float movementSpeed = 8;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = movement * movementSpeed;
        if (
            Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.D)
        )
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetMouseButton(0))
        {
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<EnemyMovement>().hp -= 5;
    }
}
