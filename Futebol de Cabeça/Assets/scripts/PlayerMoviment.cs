using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float speed = 2;
    public float jumpForce;
    public bool isGrounded = false;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
            
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();

        }
    }

    private void MoveLeft()
    {
        Vector2 targetPos = new Vector2(transform.position.x - 1, transform.position.y);
        transform.position = Vector2.Lerp(transform.position, targetPos, speed * Time.deltaTime);

    }
    private void MoveRight()
    {
        Vector2 targetPos = new Vector2(transform.position.x + 1, transform.position.y);
        transform.position = Vector2.Lerp(transform.position, targetPos, speed * Time.deltaTime);
        
    }
    private void Jump()
    {
        if (isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;

        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "terreno")
        {
            isGrounded = true;

        }
    }
}
