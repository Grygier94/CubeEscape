using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour {

    public AudioClip sound;

    // readonly
    Button button { get { return GetComponent<Button>(); } }
    AudioSource audioSource { get { return GetComponent<AudioSource>(); } }

    //dodaj komponent AudioSource i ustaw klip
    void Start () {
        gameObject.AddComponent<AudioSource>();
        audioSource.clip = sound;
        audioSource.playOnAwake = false;

        //dodaj event listener onClick na metode PlaySound
        button.onClick.AddListener(PlaySound);
	}

    public void PlaySound()
    {
        audioSource.Play();
    }
}
