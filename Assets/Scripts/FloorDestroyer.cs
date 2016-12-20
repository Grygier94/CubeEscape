using UnityEngine;
using System.Collections;

public class FloorDestroyer : MonoBehaviour
{

    Transform player;
    float timeToDestroy = 0.5f;
    bool touched;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (transform.position.x < player.position.x - 5f || timeToDestroy <= 0)
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