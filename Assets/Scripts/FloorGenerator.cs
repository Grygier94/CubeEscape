using UnityEngine;
using System.Collections;

public class FloorGenerator : MonoBehaviour
{
    public GameObject prefab;
    private float distanceForNewCube = 0F;
    private System.Random random;
    public bool justCreatedCube;
    public bool justCreatedGap;

    private Transform player;
    private Transform floor;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        floor = GameObject.FindGameObjectWithTag("Floor").transform;

        this.random = new System.Random();    
    }

    void Update()
    {
        if (4.533F + distanceForNewCube < player.position.x + 10f)
            GenerateCube();
    }

    void GenerateCube()
    {
        if (FloorShouldBeCreated())
        {
            GenerateFloorCube();
            justCreatedCube = true;
            justCreatedGap = false;
        }
        else
        {
            justCreatedCube = false;
            justCreatedGap = true;
        }
        distanceForNewCube++;
    }
    bool FloorShouldBeCreated()
    {
        return (!justCreatedCube || random.Next(2, 5) % 2 == 0);
    }
    void GenerateFloorCube()
    {
        GameObject cube = Instantiate(prefab);
        cube.transform.position = new Vector3(4.533F + distanceForNewCube, -0.7F, 10);
        cube.transform.parent = floor;
    }
}
