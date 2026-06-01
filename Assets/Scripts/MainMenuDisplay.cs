using System;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuDisplay : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject instructionScreen;
    

    private void OnEnable()
    {
        if (GameSettings.IsGameOver)
        {
            mainMenu.SetActive(false);
            loseScreen.SetActive(true);
            instructionScreen.SetActive(false);
            GameSettings.IsGameOver = false;
        }
        else
        {
            mainMenu.SetActive(true);
            loseScreen.SetActive(false);
            instructionScreen.SetActive(false);
        }
        
    }


    public void MainMenu()
    {
        mainMenu.SetActive(true);
        loseScreen.SetActive(false);
        instructionScreen.SetActive(false);
    }

    public void InstructionScreen()
    {
        mainMenu.SetActive(false);
        loseScreen.SetActive(false);
        instructionScreen.SetActive(true);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}