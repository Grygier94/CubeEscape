﻿using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    public float lowForceX;
    public float lowForceY;
    public float forceX;
    public float forceY;

    bool isJumping = false;
    float rotation;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isJumping)
            Jump();

        if (Input.GetMouseButtonDown(0) && !isJumping)
            BigJump();

        if (isJumping && rotation < 180)
            Rotate();
    }


    void Jump()
    {
        isJumping = true;
        rotation = 0;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(lowForceX, lowForceY), ForceMode2D.Impulse);
    }
    void BigJump()
    {
        isJumping = true;
        rotation = 90;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
    }
    void Rotate()
    {
        rotation += 9f;
        transform.rotation = Quaternion.AngleAxis(rotation, Vector3.back);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor" && isJumping)
        {
            isJumping = false;

            //Zeruj prędkość
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //Ustaw gracza na środku pola
            transform.position = new Vector2(col.gameObject.transform.position.x + 0.51f, transform.position.y);
        }
    }
}