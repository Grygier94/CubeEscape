using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour {
    public GameObject prefab;
    private float distanceForNewObstacle = 0F;
    private System.Random random;
    private bool justCreatedObstacle;
    private Transform player;
    private Transform obstacle;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        obstacle = GameObject.FindGameObjectWithTag("Obstacle").transform;

        this.random = new System.Random();
    }
	
	// Update is called once per frame
	void Update () {
        if (4.533F + distanceForNewObstacle < player.position.x + 10f)
            GenerateObstacle();
    }
    void GenerateObstacle()
    {
        if(ObstacleShouldBeCreated())
        {
            GenerateObstaclePrefab();
        }
        distanceForNewObstacle++;
    }
    bool ObstacleShouldBeCreated()
    {
        return random.Next(2, 5) % 2 == 0;
    }
    void GenerateObstaclePrefab()
    {
        GameObject cube = Instantiate(prefab);
        cube.transform.position = new Vector3(1.0F + distanceForNewObstacle, -0.43F, 0);
    }
}
