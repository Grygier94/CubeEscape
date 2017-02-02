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
            
            new Color[] { new Color(0.066f, 0.776f, 0.219f), new Color(0.937f, 0.592f, 0.031f), new Color(0.827f, 0.247f, 0.415f) },
            new Color[] { new Color(0.964f, 0.933f, 823f), new Color(0.258f, 0.494f, 0f), new Color(0.976f, 0.592f, 0.109f) },
            new Color[] { new Color(1f, 0.815f, 0.203f), new Color(0.56f, 0.764f, 0.921f), new Color(0.839f, 0.364f, 0.494f) }
        };

        int randomColor = (int)UnityEngine.Random.Range(0, 5.99f);
        player.color = colors[randomColor][0];
        obstacle.color = floorCube.color = colors[randomColor][1];
        background.color = colors[randomColor][2];

        UpdateColorOfExistingFloor(randomColor);
    }

    void UpdateColorOfExistingFloor(int colorNumber)
    {
        SpriteRenderer[] allChildren = floor.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in allChildren)
        {
            child.color = colors[colorNumber][1];
        }
    }
}
