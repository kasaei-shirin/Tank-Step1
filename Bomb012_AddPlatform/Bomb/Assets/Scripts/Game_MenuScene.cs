using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class Game_MenuScene : MonoBehaviour
{
    public GameObject SettingPagGameHolder,VictoryMessageHolder,MessageBoxHolder;

    public Text viberation, sound, music;
    bool statusViberation = true, statusSound = true, statusMusic = true;
    int n, z;
    public void Resume_Button()
    {
        SettingPagGameHolder.SetActive(false);
        Share.attackButton = true;

    }
    public void Setting_Button()

    {
       
        SettingPagGameHolder.SetActive(true);
        Share.attackButton = false;

    }
    public void Viberation_Button()
    {

        if (statusViberation)
        {
            viberation.text = "Viberation: OFF";
            statusViberation = false;


        }
        else
        {
            viberation.text = "Viberation: ON";
            statusViberation = true;


        }
    }
    public void Sound_Button()
    {

        if (statusSound)
        {

            statusSound = false;

            sound.text = "Sound: OFF";
        }
        else
        {

            statusSound = true;

            sound.text = "Sound: ON";
        }


    }
    public void Music_Button()
    {
        if (statusMusic)
        {

            statusMusic = false;
            music.text = "Music: OFF";
        }
        else
        {

            statusMusic = true;

            music.text = "Music: ON";
        }

        

    }

    public void BackFromGameToMaiinMenu()
    {
        SettingPagGameHolder.SetActive(false);

    }
    public void Next_Button() {
        VictoryMessageHolder.SetActive(false);
        Share.attackButton = true;
    }
    public void Retry_Button()
    {
        VictoryMessageHolder.SetActive(false);
        Share.attackButton = true;

    }
    public void OkMessageBox_Button() {
        MessageBoxHolder.SetActive(false);

    }
    public void OnMovementPress()
    {

        Share.moveButton = true;
        Share.attackButton = false;
    }

    public void OnAttackPress()
    {

        Share.attackButton = true;
        Share.moveButton = false;
        //  z++;
        //  Debug.Log("Button clicked " + z + " times.");
    }



}
