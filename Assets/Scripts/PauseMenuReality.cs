﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuReality : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public Canvas GameCanvas;
    public GameObject pauseMenu;
    public Camera GameCamera;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        GameCanvas.worldCamera = GameCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
