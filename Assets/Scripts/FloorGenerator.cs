using UnityEngine;
using System.Collections;

public class FloorGenerator : MonoBehaviour {
    public GameObject prefab;
    private float distanceForNewCube = 0F;
    private System.Random random;
    private float startAfterSeconds = 1.0f;
    private float timeBetweenInvocations = 0.3f;
    private bool justCreatedCube;
    // Use this for initialization
    void Start () {
        this.random = new System.Random();
        InvokeRepeating("GenerateCube", startAfterSeconds, timeBetweenInvocations);
    }

    void GenerateCube()
    {
        if(FloorShouldBeCreated())
        {
            GenerateFloorCube();
            justCreatedCube = true;
        }
        else
        {
            justCreatedCube = false;
        }
        distanceForNewCube++;

    }
    bool FloorShouldBeCreated()
    {
        return (!justCreatedCube || random.Next(2, 5) % 2  == 0);
    }
    void GenerateFloorCube()
    {
        GameObject cube = (GameObject)Instantiate(prefab);
        cube.transform.position = new Vector3(4.533F + distanceForNewCube, -1.95F, 10);
    }
}
