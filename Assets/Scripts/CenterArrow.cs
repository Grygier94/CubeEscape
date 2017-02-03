using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CenterArrow : MonoBehaviour {

    float position = 120;

	void Update () {
        // Jesli przezroczystosc strzalek jest <= 0.5 i jesli strzalki nie sa na srodku to zjezdzaja w dol
        if (GetComponent<Image>().color.a <= 0.5f && transform.position.y > position)
            transform.position -= new Vector3(0f,1f,0f);
	}
}
