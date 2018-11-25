using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader INSTANCE = null;

    public GameObject mainMenuPanel;
    public GameObject tapToPlayLabel;
    public GameObject mainMenuButton;

    public bool MainMenuOn { get; set; }
    
    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            if (INSTANCE != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        mainMenuPanel.gameObject.SetActive(false); // Close Main Menu
        mainMenuButton.gameObject.SetActive(true); // Activate Main Menu button
        MainMenuOn = false;

        // At this point the game did not start yet
        tapToPlayLabel.SetActive(true); // Label to tap to play
        tapToPlayLabel.GetComponent<FlashingText>().StartText(); // Start the text
        GameManager.INSTANCE.ControlsON = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        DestroyAllFallingObj();
        MainMenu();
    }

    public void MainMenu()
    {
        mainMenuPanel.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(false);
        MainMenuOn = true;

        GameManager.INSTANCE.FirstTap = false;
        Time.timeScale = 0; // Pause the game
    }

    private void DestroyAllFallingObj()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag("FallingObj");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }
}
