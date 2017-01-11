using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

    public SpriteRenderer player;
    public SpriteRenderer floor;
    public SpriteRenderer obstacle;
    public SpriteRenderer background;

    void Start () {
        player.color = Color.red;
        obstacle.color = floor.color = Color.yellow;
        background.color = Color.blue;
    }
	
	void Update () {
	
	}
}
