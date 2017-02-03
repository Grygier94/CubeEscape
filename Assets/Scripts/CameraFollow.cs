using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform player;

	void Update () {
        //stopniowo przesuwa kamere w strone gracza
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x + 0.73f, transform.position.y, transform.position.z), 0.4f);
    }
}
