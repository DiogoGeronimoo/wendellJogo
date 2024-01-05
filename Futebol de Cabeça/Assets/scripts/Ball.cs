using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManeger gm;
    private Rigidbody2D rb;

    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManeger").GetComponent<GameManeger>();
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PortalPlayer")
        {
            gm.aiscore++;
            transform.position = startPos;
            rb.velocity = Vector2.zero;

        }
        else if (col.gameObject.tag == "PortalInimigo")
        {
            gm.playerScore++;
            transform.position = startPos;
            rb.velocity = Vector2.zero;

        }
    }
}
