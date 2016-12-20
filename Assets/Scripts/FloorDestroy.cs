using UnityEngine;
using System.Collections;

public class FloorDestroy : MonoBehaviour {

    Transform Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

	void Update () {
        if (transform.position.x < Player.position.x - 5f)
            Destroy(gameObject);        
	}
}
