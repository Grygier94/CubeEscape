using UnityEngine;
using System.Collections;

public class MusicChanger : MonoBehaviour {

    public bool isMenu;
    public AudioClip music;
    AudioSource musicSource;

    void Start()
    {
        musicSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();

        if (isMenu && musicSource.clip.name == "MenuMusic")
            return;

        musicSource.clip = music;
        musicSource.Play();
    }
}
