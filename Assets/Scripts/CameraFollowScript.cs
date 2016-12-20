using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    public Transform player;

	void Update () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x + 0.73f, transform.position.y, transform.position.z), 0.4f);
    }
}
