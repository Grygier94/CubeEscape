using UnityEngine;
using System.Collections;

public class FloorGenerator : MonoBehaviour
{
    public GameObject prefab;
    private float distanceForNewCube = 0F;
    private System.Random random;
    private bool justCreatedCube;
    private Transform player;
    private Transform floor;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        floor = GameObject.FindGameObjectWithTag("Floor").transform;

        this.random = new System.Random();
        InvokeRepeating("GenerateCube", 0, 0.3f);
    }

    void GenerateCube()
    {
        if (4.533F + distanceForNewCube < player.position.x + 10f)
        {
            if (FloorShouldBeCreated())
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
    }
    bool FloorShouldBeCreated()
    {
        return (!justCreatedCube || random.Next(2, 5) % 2 == 0);
    }
    void GenerateFloorCube()
    {
        GameObject cube = Instantiate(prefab);
        cube.transform.position = new Vector3(4.533F + distanceForNewCube, -1.95F, 10);
        cube.transform.parent = floor;
    }
}
