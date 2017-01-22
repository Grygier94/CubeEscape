using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    public Sprite soundOn;
    public Sprite soundOff;
    bool isMute;

    void Start()
    {

        if (PlayerPrefs.GetInt("isMute") == 1)
            Mute();
    }

    public void Mute()
    {
        isMute = !isMute;

        if(isMute)
        {
            PlayerPrefs.SetInt("isMute", 1);
            AudioListener.volume = 0;
            GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            PlayerPrefs.SetInt("isMute", 0);
            AudioListener.volume = 1;
            GetComponent<Image>().sprite = soundOn;
        }
    }
}
