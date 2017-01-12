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
        if (1.513F + distanceForNewObstacle < player.position.x + 10f)
            GenerateObstacle();
    }
    void GenerateObstacle()
    {
        if(ObstacleShouldBeCreated())
        {
            GenerateObstaclePrefab();
            justCreatedObstacle = true;
            
        }
        else
        {
            justCreatedObstacle = false;
        }
        distanceForNewObstacle++;
    }
    bool ObstacleShouldBeCreated()
    {
        return !justCreatedObstacle && random.Next(2, 11) % 3 == 0 && !gapIsAhead();
    }
    // TO DO
    bool gapIsAhead()
    {
        GameObject cubeOnNextPosition = FindAt(new Vector3(3.533F , -0.7f,10));
       // Debug.Log(cubeOnNextPosition);
        return cubeOnNextPosition == null;
    }
    void GenerateObstaclePrefab()
    {
        GameObject obstacle = Instantiate(prefab);
        obstacle.transform.position = new Vector3(3.513F + distanceForNewObstacle, 0.3F, 0);
    }

    GameObject FindAt(Vector3 position) {
        // get all colliders that intersect pos:
        Collider[] cols = Physics.OverlapSphere(position, 50f);
        // find the nearest one:
        float distance = Mathf.Infinity;
        GameObject nearest = null;
        foreach (Collider col in cols){
            Debug.Log(col);
            // find the distance to pos:
            float d = Vector3.Distance(position, col.transform.position);
            if (d<distance){ // if closer...
                distance = d; // save its distance... 
                nearest = col.gameObject; // and its gameObject           
     }
   }
   return nearest;
 }
}
