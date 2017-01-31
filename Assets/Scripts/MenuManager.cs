using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    bool exitConfirmed;

    // Use this for initialization
    void Start () {
        SaveLoadData.Load();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (exitConfirmed)
                Application.Quit();
            else
                exitConfirmed = true;
        }

        if (Input.touchCount > 0 && exitConfirmed)
            exitConfirmed = false;
    }
}
