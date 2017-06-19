using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class Controller : MonoBehaviour
{
    public Text scoreText;
    public float lowForceX;
    public float lowForceY;
    public float forceX;
    public float forceY;

    public AudioSource audioJump;
    public AudioSource audioLand;
    public AudioSource audioCollision;

    bool isJumping = false;
    bool isJumpingFar = false;
    float rotation;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2 && Input.mousePosition.y < Screen.height * 0.75f && !isJumping && !isJumpingFar)
            Jump();

        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x <= Screen.width / 2 && Input.mousePosition.y < Screen.height * 0.75f && !isJumping && !isJumpingFar)
            BigJump();

        if (isJumpingFar && rotation < 180)
            Rotate(9f);

        if (isJumping && rotation < 90)
            Rotate(7f);
    }


    void Jump()
    {
        isJumping = true;
        rotation = 0;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(lowForceX, lowForceY), ForceMode2D.Impulse);
        audioJump.Play();
    }
    void BigJump()
    {
        isJumpingFar = true;
        rotation = 0;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        audioJump.Play();
    }
    void Rotate(float speed)
    {
        rotation += speed;
        transform.rotation = Quaternion.AngleAxis(rotation, Vector3.back);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "FloorCube" && (isJumping || isJumpingFar))
        {
            audioLand.Play();
            if (isJumping)
                GameManager.score++;
            else if (isJumpingFar)
                GameManager.score += 2;
            scoreText.text = GameManager.score.ToString();
            isJumping = false;
            isJumpingFar = false;
            UpdateAchievements();

            //Zeruj prędkość
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //Zeruj rotacje
            transform.rotation = new Quaternion(0,0,0,0);
            //Ustaw gracza na środku pola
            transform.position = new Vector2(col.gameObject.transform.position.x, transform.position.y);
        }

        if (col.gameObject.tag == "Obstacle")
        {
            audioCollision.Play();
            Destroy(GetComponent<BoxCollider2D>());
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f, 15f), ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().AddTorque(10f, ForceMode2D.Impulse);
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver();
        }
    }

    void UpdateAchievements()
    {
        if (Social.localUser.authenticated)
        {
            if (GameManager.score >= 10)
                Social.ReportProgress(GPGSIds.achievement_first_steps, 100.0f, null);
            if (GameManager.score >= 25)
                Social.ReportProgress(GPGSIds.achievement_getting_better, 100.0f, null);
            if (GameManager.score >= 50)
                Social.ReportProgress(GPGSIds.achievement_not_bad, 100.0f, null);
            if (GameManager.score >= 150)
                Social.ReportProgress(GPGSIds.achievement_unstoppable, 100.0f, null);
            if (GameManager.score >= 300)
                Social.ReportProgress(GPGSIds.achievement_cube_master, 100.0f, null);
            if (GameManager.score >= 500)
                Social.ReportProgress(GPGSIds.achievement_escaped, 100.0f, null);
        }
    }
}