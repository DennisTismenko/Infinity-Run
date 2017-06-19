using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBlock : MonoBehaviour {

    Button button;

    void Start()
    {
        button = this.GetComponent<Button>();
    }
	void OnEnable()
    {
        EventHandler.pauseEvent += PauseHandler;
        EventHandler.unpauseEvent += UnpauseHandler;
    }

    void OnDisable()
    {
        EventHandler.pauseEvent -= PauseHandler;
        EventHandler.unpauseEvent -= UnpauseHandler;
    }

    void PauseHandler()
    {
        button.interactable = false;
    }

    void UnpauseHandler()
    {
        button.interactable = true;
    }
}
