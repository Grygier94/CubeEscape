using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    public float forceX;
    public float forceY;
    public float forceX1 = 4.62f;
    public float forceX2 = 4.62f;


    bool isJumping = false;
    bool isWalking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isJumping)
        {
            isJumping = true;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);

        }
        if (Input.GetMouseButtonDown(1) && !isWalking)
        {
            isWalking = true;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX1, forceX2), ForceMode2D.Impulse);

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Floor" && isJumping)
        {
            isJumping = false;
            //transform.position = new Vector2(col.gameObject.transform.position.x + 0.08f, transform.position.y);
        }
        if (col.gameObject.tag == "Floor" && isWalking)
        {
            isWalking = false;  
        }
    }
}
