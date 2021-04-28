using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MainMenuHolder;
    public GameObject DifficultyHolder;

    public GameObject OptionsMenuHolder;

    public void Start_Button()
    {
        MainMenuHolder.SetActive(false);
        DifficultyHolder.SetActive(true);
    }

    public void BackToMainMenuFromDifficulty()
    {
        MainMenuHolder.SetActive(true);
        DifficultyHolder.SetActive(false);
    }

    public void Options_Button()
    {
        MainMenuHolder.SetActive(false);
        OptionsMenuHolder.SetActive(true);
    }
 }
