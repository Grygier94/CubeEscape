using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour {

    public AudioClip sound;
    Button button { get { return GetComponent<Button>(); } }
    AudioSource audioSource { get { return GetComponent<AudioSource>(); } }

    void Start () {
        gameObject.AddComponent<AudioSource>();
        audioSource.clip = sound;
        audioSource.playOnAwake = false;

        button.onClick.AddListener(() => PlaySound());
	}

    public void PlaySound()
    {
        audioSource.Play();
    }
}
