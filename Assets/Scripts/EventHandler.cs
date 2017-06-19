using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour {

    public static bool paused = false;
    public GameObject optionsMenu;
    public Button playButton = null;
    public Button settingsButton = null;
    public Button aboutButton = null;

    public void ChangeScene(int scene)
    {
        if (paused)
        {
            Time.timeScale = 1.0f;
        }
        SceneManager.LoadScene(scene);
    }

    void Start()
    {
        optionsMenu.SetActive(false);
    }
    void OnGUI()
    {
        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Escape)
        {
            loadOptionsMenu();
        }
    }

    void loadOptionsMenu()
    {
        if (optionsMenu.activeInHierarchy)
        {
            optionsMenu.SetActive(false);
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                playButton.interactable = true;
                settingsButton.interactable = true;
                aboutButton.interactable = true;
            } else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Time.timeScale = 1.0f;
                paused = false;
            }
            

        } else
        {
            optionsMenu.SetActive(true);
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                playButton.interactable = false;
                settingsButton.interactable = false;
                aboutButton.interactable = false;
            } else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Time.timeScale = 0.0f;
                paused = true;
            }
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
