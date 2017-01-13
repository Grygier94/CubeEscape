using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    public bool partial;
    float time = 3.0f;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            return;
        }
        else
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
