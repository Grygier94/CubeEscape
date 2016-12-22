using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {

    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (transform.position.x < player.position.x - 5f)
            Destroy(gameObject);
    }
}
