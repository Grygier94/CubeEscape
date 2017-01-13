using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    public Sprite soundOn;
    public Sprite soundOff;
    bool isMute;

    public void Mute()
    {
        isMute = !isMute;

        if(isMute)
        {
            AudioListener.volume = 0;
            GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            AudioListener.volume = 1;
            GetComponent<Image>().sprite = soundOn;
        }
    }
}
