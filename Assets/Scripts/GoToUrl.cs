using UnityEngine;
using System.Collections;

public class GoToUrl : MonoBehaviour {

	public void GoTo(string url)
    {
        Application.OpenURL(url);
    }
}
    