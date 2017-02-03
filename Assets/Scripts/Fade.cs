using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    public bool partial;
    float time = 3.0f;
    bool isPlaying = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            isPlaying = true;

        if (time >= 0 && isPlaying)
        {
            time -= Time.deltaTime;
            return;
        }
        else if(time < 0 && isPlaying)
        {
            if (partial)
            {
                if (GetComponent<Image>().color.a >= 0.5f)
                    GetComponent<Image>().color -= new Color(0f, 0f, 0f, 0.01f);
            }
            else if (GetComponent<Image>().color.a > 0f)
            {
                GetComponent<Image>().color -= new Color(0f, 0f, 0f, 0.01f);
            }
        }
    }
}
