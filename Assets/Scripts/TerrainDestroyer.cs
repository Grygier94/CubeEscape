using UnityEngine;
using System.Collections;

public class TerrainDestroyer : MonoBehaviour
{
    public Sprite destroyedCube;
    float timeToDestroy = 0.5f;
    bool touched;
    int level = 0;

    void Update()
    {
        SetLevel();

        if (timeToDestroy <= 0 && GetComponent<Rigidbody2D>().isKinematic)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<SpriteRenderer>().sprite = destroyedCube;
        }

        if (transform.position.y < -5.5f)
            Destroy(gameObject);

        if (touched)
            timeToDestroy -= 0.01f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
            touched = true;
    }

    void SetLevel()
    {
        if (GameManager.score > 10 && level == 0)
        {
            timeToDestroy = 0.4f;
            level = 1;
        }
        if (GameManager.score > 20 && level == 1)
        {
            timeToDestroy = 0.3f;
            level = 2;
        }
        if (GameManager.score > 30 && level == 2)
        {
            timeToDestroy = 0.2f;
            level = 3;
        }
        if (GameManager.score > 40 && level == 3)
        {
            timeToDestroy = 0.1f;
            level = 4;
        }
        if (GameManager.score > 50 && level == 4)
        {
            timeToDestroy = 0.05f;
            level = 5;
        }
    }
}