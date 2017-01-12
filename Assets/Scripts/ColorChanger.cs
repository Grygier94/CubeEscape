using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

    public SpriteRenderer player;
    public SpriteRenderer floor;
    public SpriteRenderer obstacle;
    public SpriteRenderer background;

    Color[][] colors;

    void Start() {
        colors = new Color[][] {
            new Color[] { new Color(1f, 0.815f, 0.203f), new Color(1f, 0.298f, 0.231f), new Color(0f, 0.447f, 0.733f) },
            new Color[] { new Color(1f, 0.815f, 0.203f), new Color(1f, 0.298f, 0.231f), new Color(0f, 0.447f, 0.733f) },
            new Color[] { new Color(1f, 0.815f, 0.203f), new Color(1f, 0.298f, 0.231f), new Color(0f, 0.447f, 0.733f) },
            new Color[] { new Color(1f, 0.815f, 0.203f), new Color(1f, 0.298f, 0.231f), new Color(0f, 0.447f, 0.733f) },
            new Color[] { new Color(1f, 0.815f, 0.203f), new Color(1f, 0.298f, 0.231f), new Color(0f, 0.447f, 0.733f) },
            new Color[] { new Color(1f, 0.815f, 0.203f), new Color(1f, 0.298f, 0.231f), new Color(0f, 0.447f, 0.733f) },
            new Color[] { new Color(1f, 0.815f, 0.203f), new Color(1f, 0.298f, 0.231f), new Color(0f, 0.447f, 0.733f) },
            new Color[] { new Color(1f, 0.815f, 0.203f), new Color(1f, 0.298f, 0.231f), new Color(0f, 0.447f, 0.733f) },
            new Color[] { new Color(1f, 0.815f, 0.203f), new Color(1f, 0.298f, 0.231f), new Color(0f, 0.447f, 0.733f) },
            new Color[] { new Color(1f, 0.815f, 0.203f), new Color(1f, 0.298f, 0.231f), new Color(0f, 0.447f, 0.733f) }
        };

        Random rand = new Random();

        player.color = colors[0][0];
        obstacle.color = floor.color = colors[0][1];
        background.color = colors[0][2];
    }
	
	void Update () {
	
	}
}
