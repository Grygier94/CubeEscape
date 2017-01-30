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
        if (Input.GetMouseButtonDown(0) && exitConfirmed)
            exitConfirmed = false;

        if (Input.GetKeyDown(KeyCode.Escape))
            exitConfirmed = true;

        if (Input.GetKeyDown(KeyCode.Escape) && exitConfirmed)
            Application.Quit();
    }
}
