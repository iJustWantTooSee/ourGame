﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFromMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("LVL1CUTSCENE");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
