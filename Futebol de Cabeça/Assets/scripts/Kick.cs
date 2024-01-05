using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public float force = 100f;

    public GameObject ball;

    private Rigidbody2D rbBall;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        rbBall = ball.GetComponent<Rigidbody2D>();
        this.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Vector2 pos = (transform.position - col.gameObject.transform.position).normalized;
            rbBall.AddForce(-pos * force, ForceMode2D.Impulse);

        }
    }
}
