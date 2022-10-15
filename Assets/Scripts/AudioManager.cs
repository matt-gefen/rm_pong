using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource victoryMusic;
    void Start()
    {
        backgroundMusic.Play();
        victoryMusic.Stop();
    }

    void Update()
    {
        
    }

    public void StartBGAudio() {
        victoryMusic.Stop();
        backgroundMusic.Play();
    }
    public void StartVictoryAudio() {
        backgroundMusic.Stop();
        victoryMusic.Play();
    }

    public void ChangeBGM(AudioClip music) {
        // StopAudio();
        backgroundMusic.clip = music;
        backgroundMusic.Play();
    }

}
