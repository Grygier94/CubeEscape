using UnityEngine;
using System.Collections;

public class ObstacleRotation : MonoBehaviour {
	
	void Update () {
        transform.Rotate(Vector3.forward * Time.timeScale * 3f);
	}
}
