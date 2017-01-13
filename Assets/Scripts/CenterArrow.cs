using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CenterArrow : MonoBehaviour {

    float position = 100;

	void Update () {
        if (GetComponent<Image>().color.a <= 0.5f && GetComponent<RectTransform>().position.y > position)
            transform.position -= new Vector3(0f,1f,0f);
	}
}
