using UnityEngine;
using System.Collections;

public class FloorDestroyer : MonoBehaviour
{
    public Sprite destroyedCube;
    float timeToDestroy = 0.5f;
    bool touched;

    void Update()
    {
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
}