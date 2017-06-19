using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour {

    public delegate void pause();
    public static event pause pauseEvent;
    public static event pause unpauseEvent;

    private float currentTimeScale = 1.0f;

    public GameObject optionsMenu;

    public void ChangeScene(int scene)
    {
        unpauseEvent();
        SceneManager.LoadScene(scene);
    }

    void Start()
    {
        optionsMenu.SetActive(false);
    }

    void OnEnable()
    {
        pauseEvent += PauseGame;
        unpauseEvent += UnpauseGame;
    }

    void OnDisable()
    {
        pauseEvent -= PauseGame;
        unpauseEvent -= UnpauseGame;
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
            unpauseEvent();
        } else
        {
            optionsMenu.SetActive(true);
            pauseEvent();
        }
    }

    void PauseGame()
    {
        currentTimeScale = Time.timeScale;
        Time.timeScale = 0.0f;
    }

    void UnpauseGame()
    {
        Time.timeScale = currentTimeScale;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
