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
            DestroyPieceOfFloor();

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

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
            DestroyPieceOfFloor();
    }

    void DestroyPieceOfFloor()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        Destroy(GetComponent<BoxCollider2D>());
        GetComponent<SpriteRenderer>().sprite = destroyedCube;
    }

    void SetLevel()
    {
        if (GameManager.score > 15 && level == 0)
        {
            timeToDestroy = 0.4f;
            level = 1;
        }
        if (GameManager.score > 30 && level == 1)
        {
            timeToDestroy = 0.3f;
            level = 2;
        }
        if (GameManager.score > 45 && level == 2)
        {
            timeToDestroy = 0.2f;
            level = 3;
        }
        if (GameManager.score > 60 && level == 3)
        {
            timeToDestroy = 0.1f;
            level = 4;
        }
        if (GameManager.score > 75 && level == 4)
        {
            timeToDestroy = 0.08f;
            level = 5;
        }
        if (GameManager.score > 90 && level == 5)
        {
            timeToDestroy = 0.065f;
            level = 6;
        }
        if (GameManager.score > 125 && level == 6)
        {
            timeToDestroy = 0.05f;
            level = 7;
        }
        if (GameManager.score > 200 && level == 7)
        {
            timeToDestroy = 0.04f;
            level = 8;
        }
    }
}