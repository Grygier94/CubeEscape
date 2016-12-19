using UnityEngine;
using System.Collections;

public class ObjectCleanup : MonoBehaviour {

    private float requiredDistanceForDestruction = 12f;
    private float startAfterSeconds = 5.0f;
    private float timeBetweenInvocations = 5f;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CheckForFarObjects", startAfterSeconds, timeBetweenInvocations);
    }


    void CheckForFarObjects()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Floor");
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");

        foreach (GameObject tile in tiles)
        {
            float distanceBetweenCameraAndTile = camera.transform.position.x - tile.transform.position.x;
            if (distanceBetweenCameraAndTile > requiredDistanceForDestruction) Destroy(tile);
        }
    }

}
