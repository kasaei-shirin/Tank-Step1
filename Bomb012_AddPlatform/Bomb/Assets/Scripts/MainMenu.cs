using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject PauseMenu;
    public GameObject levelComplete;

    public void PlayGame() {
        Menu.SetActive(false);
    }
    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void BackMainMenu() {

        PauseMenu.SetActive(false);
      Menu.SetActive(true);

    }
    public void Resume() {
        PauseMenu.SetActive(false);
        Share.attackButton=true;


    }
    public void PlayAgaineGame()
    {
        levelComplete.SetActive(false);
        Share.attackButton = true;
    }

    public void BackMainMenuFromLevelComplete()
    {

        levelComplete.SetActive(false);
        Menu.SetActive(true);

    }

}
