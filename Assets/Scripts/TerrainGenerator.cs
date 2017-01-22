using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour
{
    private const float OBSTACLE_Y_POSTION_HIGH = 2F;
    private const float OBSTACLE_Y_POSTION_MID = 0.3F;
    private const float OBSTACLE_Y_POSTION_LOW = -0.6F;

    public GameObject cubePrefab;
    public GameObject ObstaclePrefab;
    private float distanceForObject = 0F;
    private float obstacleYPosition = 0.3F;

    private System.Random random;
    private bool justCreatedCube;
    private bool justCreatedObstacle;
    private bool createdFloorInLastMove;
    private bool createdObstacleInLastMove;

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
        if (4.533F + distanceForObject < player.position.x + 10f)
        {
            GenerateCube();
            GenerateObstacle();
            distanceForObject++;
        }

    }

    void GenerateCube()
    {
        createdFloorInLastMove = justCreatedCube;
        if (FloorShouldBeCreated())
        {
            GenerateFloorCube();
            justCreatedCube = true;
        }
        else
        {
            justCreatedCube = false;
        }
    }
    bool FloorShouldBeCreated()
    {
        return (!justCreatedCube || justCreatedObstacle || random.Next(2, 5) % 2 == 0);
    }
    void GenerateFloorCube()
    {
        GameObject cube = Instantiate(cubePrefab);
        cube.transform.position = new Vector3(4.533F + distanceForObject, -0.7F, 10);
        cube.transform.parent = floor;
    }
    /*=============================OBSTACLE GENERATION================================*/
    void GenerateObstacle()
    {
        createdObstacleInLastMove = justCreatedObstacle;
        if (ObstacleShouldBeCreated())
        {
            GenerateObstaclePrefab();
            justCreatedObstacle = true;

        }
        else
        {
            justCreatedObstacle = false;
        }
    }
    bool ObstacleShouldBeCreated()
    {
        return !justCreatedObstacle && !createdGapInLastMove() && random.Next(2, 4) % 3 == 0;
    }
    bool createdGapInLastMove()
    {
        return !createdFloorInLastMove;
    }

    void GenerateObstaclePrefab()
    {
        GameObject obstacle = Instantiate(ObstaclePrefab);
        if (justCreatedCube)
        {
            if (positionShouldBeHigh())
                obstacleYPosition = OBSTACLE_Y_POSTION_HIGH;
            else
                obstacleYPosition = OBSTACLE_Y_POSTION_MID;
        }
        else
        {
            if (positionShouldBeLow())
                obstacleYPosition = OBSTACLE_Y_POSTION_LOW;
            else
                obstacleYPosition = OBSTACLE_Y_POSTION_MID;
        }
        obstacle.transform.position = new Vector3(4.513F + distanceForObject, obstacleYPosition, 0);
    }
    bool positionShouldBeHigh()
    {
        return random.Next(1, 3) % 2 == 0;
    }
    bool positionShouldBeLow()
    {
        return random.Next(1, 3) % 2 == 0;
    }
}
