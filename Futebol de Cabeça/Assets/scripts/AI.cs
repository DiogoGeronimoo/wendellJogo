using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AI : MonoBehaviour
{
    public float rangedDefence, speed;
    public Transform defence;

    public GameObject Ball;

    private Rigidbody2D rb;

    public float JumpForce;

    public bool isGrouded = false;
    // Start is called before the first frame update
    void Start()
    {
        Ball = GameObject.FindGameObjectWithTag("Ball");
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        if (Mathf.Abs(Ball.transform.position.x - transform.position.x) > rangedDefence)
        {
            if (Ball.transform.position.x > transform.position.x)
            {
                transform.Translate(Time.deltaTime * speed, 0,0);
            }
            else if (Ball.transform.position.x < transform.position.x)
            {
                transform.Translate(- Time.deltaTime * speed, 0,0);
            }
            else if (Ball.transform.position.x == transform.position.x)
            {
                transform.position = new Vector2(transform.position.x + 1.5f, transform.position.y);

            }
            
        }
        else
        {
            if (transform.position.x < defence.position.x)
            {
                transform.Translate(Time.deltaTime * speed, 0,0);
            }
            else
            {
                transform.Translate(0,0,0);
            }
        }

    }

    private void Jump()
    {
        float dist = Vector2.Distance(Ball.transform.position, transform.position);

        if (dist < 1f && isGrouded == true)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isGrouded = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "terreno")
        {
            isGrouded = true;

        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "terreno")
        {
            isGrouded = false;

        }
    }
}
