using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryAudio : MonoBehaviour
{
    public AudioSource victoryMusic;
    public GameObject audioManager;
    void Start()
    {
        victoryMusic.Stop();
        audioManager = GameObject.FindGameObjectWithTag("Bg");
    }

    void Update()
    {
        
    }

    public void StartAudio() {
        audioManager.SendMessage("StopAudio", null, SendMessageOptions.RequireReceiver);
        victoryMusic.Play();
    }
}
