using UnityEngine;
using System.Collections;

public class FloorDestroyer : MonoBehaviour
{
    float timeToDestroy = 0.5f;
    bool touched;

    void Update()
    {
        if (timeToDestroy <= 0)
            Destroy(gameObject);

        if(touched)
            timeToDestroy -= 0.01f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
            touched = true;
    }
}