using UnityEngine;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour {

    public delegate void pause();
    public static event pause pauseEvent;
    public static event pause unpauseEvent;


    public delegate void GameBehaviour();
    public static event GameBehaviour startGame;
    public static event GameBehaviour endGame;

    private float currentTimeScale = 1.0f;
    private PlayerController pc;
    private int sceneIndex;

    public GameObject optionsMenu;
    
    public void ChangeScene(int scene)
    {
        unpauseEvent();
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 1)
        {
            GameObject player = GameObject.Find("Player");
            pc = player.GetComponent<PlayerController>();
        } else
        {
            pc = null;
        }
    }

    void OnEnable()
    {
        Player.playerDead += EndGame;
        pauseEvent += PauseGame;
        pauseEvent += DisablePlayer;
        unpauseEvent += EnablePlayer;
        unpauseEvent += UnpauseGame;
        SceneManager.sceneLoaded += LoadScene;
    }


    void OnDisable()
    {
        Player.playerDead -= EndGame;
        pauseEvent -= PauseGame;
        pauseEvent -= DisablePlayer;
        unpauseEvent -= EnablePlayer;
        unpauseEvent -= UnpauseGame;
        SceneManager.sceneLoaded -= LoadScene;
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

    void LoadScene(Scene s, LoadSceneMode m)
    {
        if (s.name == "MainMenu")
        {
            LoadMainMenu();
        } else if (s.name == "Space")
        {
            LoadGame();
        }
    }

    void LoadMainMenu()
    {
        optionsMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void LoadGame()
    {
        optionsMenu.SetActive(false);
        startGame();
    }

    void EndGame()
    {
        endGame();
    }

    void EnablePlayer()
    {
        if (sceneIndex == 1)
        {
            pc.enabled = true;
        }
        
    }

    void DisablePlayer()
    {
        if (sceneIndex == 1)
        {
            pc.enabled = false;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
