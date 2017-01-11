using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    Transform player;
	void Start () {
	    player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	void Update () {
        if (player.position.y < -10f)
            GameOver();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(4);
    }

}
