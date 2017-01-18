using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Text scoreText;
    public float lowForceX;
    public float lowForceY;
    public float forceX;
    public float forceY;

    bool isJumping = false;
    bool isJumpingFar = false;
    float rotation;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isJumping && !isJumpingFar)
            Jump();

        if (Input.GetMouseButtonDown(0) && !isJumping && !isJumpingFar)
            BigJump();

        if (isJumpingFar && rotation < 180)
            Rotate();

        if (isJumping && rotation < 90)
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
        isJumpingFar = true;
        rotation = 0;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
    }
    void Rotate()
    {
        rotation += 9f;
        transform.rotation = Quaternion.AngleAxis(rotation, Vector3.back);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "FloorCube" && (isJumping || isJumpingFar))
        {
            if (isJumping)
                GameManager.score++;
            else if (isJumpingFar)
                GameManager.score += 2;
            scoreText.text = GameManager.score.ToString();
            isJumping = false;
            isJumpingFar = false;

            //Zeruj prędkość
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //Ustaw gracza na środku pola
            transform.position = new Vector2(col.gameObject.transform.position.x, transform.position.y);
        }

        if (col.gameObject.tag == "Obstacle")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver();
        }
    }
}