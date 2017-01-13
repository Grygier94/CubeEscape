using UnityEngine;
using System.Collections;
using System;

public class ColorChanger : MonoBehaviour {

    public SpriteRenderer player;
    public SpriteRenderer floorCube;
    public SpriteRenderer obstacle;
    public SpriteRenderer background;

    public GameObject floor;

    Color[][] colors;

    void Start() {
        colors = new Color[][] {
            new Color[] { new Color(1f, 0.815f, 0.203f), new Color(1f, 0.298f, 0.231f), new Color(0f, 0.447f, 0.733f) },
            new Color[] { new Color(0.97f, 0.42f, 0f), new Color(0f, 0.352f, 0.372f), new Color(0f, 0.567f, 0.676f) },
            new Color[] { new Color(0.1f, 0.1f, 0.1f), new Color(0.29f, 0.30f, 0.30f), new Color(0.50f, 0.517f, 0.533f) },
            new Color[] { new Color(0.8f, 0.4f, 0.23f), new Color(0.8f, 0.8f, 0.8f), new Color(0.6f, 0.6f, 0.6f) },
            new Color[] { new Color(0.92f, 0.698f, 0f), new Color(0.796f, 0.172f, 0.098f), new Color(0.678f, 0.784f, 0.005f) },
            new Color[] { new Color(1f, 0.815f, 0.203f), new Color(0.56f, 0.764f, 0.921f), new Color(0.839f, 0.364f, 0.494f) }
        };

        int randomColor = (int)UnityEngine.Random.Range(0, 5.99f);
        Debug.Log(randomColor);
        player.color = colors[randomColor][0];
        obstacle.color = floorCube.color = colors[randomColor][1];
        background.color = colors[randomColor][2];

        UpdateColorOfExistingFloor(randomColor);
    }
	
	void UpdateColorOfExistingFloor(int colorNumber)
    {
        SpriteRenderer []
        allChildren = floor.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in allChildren)
        {
            child.color = colors[colorNumber][1];
        }
    }
}
