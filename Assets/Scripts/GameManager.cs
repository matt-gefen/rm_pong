using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    public static bool GameOver = false;

    public GUISkin layout;

    GameObject theBall;
    private AudioManager audioManager;
    // GameObject victoryMusic;

    private SwitchMusic switchMusic;
    
    
    void Start()
    {  
        theBall = GameObject.FindGameObjectWithTag("Ball");
        // victoryMusic = GameObject.FindGameObjectWithTag("VictoryAudio");
        // GameOver = false;
        audioManager = FindObjectOfType<AudioManager>();
        switchMusic = GetComponent<SwitchMusic>();
    }
    public static void Score (string wallID) {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
        } else {
            PlayerScore2++;
        }

        if (PlayerScore1 == 2 || PlayerScore2 == 2) {
        // victoryMusic.SendMessage("StartAudio", null, SendMessageOptions.RequireReceiver);
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            audioManager.StartVictoryAudio();
        }
    }
    void OnGUI() {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            audioManager.StartBGAudio();
        }

        if (PlayerScore1 == 2)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBallWin", null, SendMessageOptions.RequireReceiver);
            
        } else if (PlayerScore2 == 2)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBallWin", null, SendMessageOptions.RequireReceiver);
        }

    }

    // public static void OnVictory(int PlayerScore1, int PlayerScore2) {
    //     if (PlayerScore1 == 2 || PlayerScore2 == 2) {
    //         // victoryMusic.SendMessage("StartAudio", null, SendMessageOptions.RequireReceiver);
    //         AudioManager audioManager = FindObjectOfType<AudioManager>();
    //         audioManager.StartVictoryAudio();
    //     }
    // }
    // Update is called once per frame
    void Update()
    {

    }
}
