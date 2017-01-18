using UnityEngine;
using System.Collections;


public class Pause : MonoBehaviour
{
    private Vector3 velocity;
    public bool Paused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().isKinematic = true;
            Paused = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().velocity = velocity;
            Paused = false;
        }
    }
}