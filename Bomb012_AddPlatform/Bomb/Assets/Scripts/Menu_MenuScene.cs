using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_MenuScene : MonoBehaviour
{
    public GameObject SettingPageMenuHolder, MainPageHolder;
    public GameObject LevelPageHolder;
 
    public GameObject ArmyUnitPageHolder;
    public GameObject Tank, Car, Soldier, Missle;
    public Text viberation,sound,music;
    
    bool statusViberation=true,statusSound=true,statusMusic = true;


    private Animator ScreenFaderAnim;
    private Canvas CanvasMenu;
    void Awake()
    {
        ScreenFaderAnim = GameObject.FindGameObjectWithTag("Fader").GetComponent<Animator>();
        CanvasMenu = gameObject.GetComponent<Canvas>();
    }


    //Arash
    public void Tank_Button()
    {
        Tank.SetActive(true);
        Car.SetActive(false);
        Soldier.SetActive(false);
        Missle.SetActive(false);
    }

    public void Car_Button()
    {
        Tank.SetActive(false);
        Car.SetActive(true);
        Soldier.SetActive(false);
        Missle.SetActive(false);
    }

    public void Soldier_Button()
    {
        Tank.SetActive(false);
        Car.SetActive(false);
        Soldier.SetActive(true);
        Missle.SetActive(false);
    }

    public void Missle_Button()
    {
        Tank.SetActive(false);
        Car.SetActive(false);
        Soldier.SetActive(false);
        Missle.SetActive(true);
    }

    public void Army_Button()
    {
        ArmyUnitPageHolder.SetActive(true);
        MainPageHolder.SetActive(false);
    }

    public void Level_Button()
    {
        MainPageHolder.SetActive(false);
        LevelPageHolder.SetActive(true);
    }

    public void Duel_Button()
    {
        Debug.Log("Duel");
    }



    public void BackFromLevelToMainPageButton()
    {
        MainPageHolder.SetActive(true);
        LevelPageHolder.SetActive(false);
    }

    public void Level_1_Button()
    {
        //this is level 1
        Debug.Log("level1");

    }

    public void Level_2_Button()
    {
        //this is level 2
        Debug.Log("level2");
    }


    public void Play_Button()
    {
        gameObject.SendMessage("FadeScreenProcessFromStart");
    }







    //
    public void Resume_Button()
    {
        SettingPageMenuHolder.SetActive(false);
        MainPageHolder.SetActive(true);

    }
    public void Setting_Button()
    {
        SettingPageMenuHolder.SetActive(true);
        MainPageHolder.SetActive(false);
    }
    public void Viberation_Button() {

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
    public void Sound_Button() {

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



    IEnumerator FadeScreenProcessFromStart()
    {
        CanvasMenu.enabled = false;
        ScreenFaderAnim.Play("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game_Scene");

    }
}
