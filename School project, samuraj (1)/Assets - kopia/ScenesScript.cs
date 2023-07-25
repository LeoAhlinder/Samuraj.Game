﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesScript : MonoBehaviour
{
    public bool BirminghamScene;
    public bool HuntingScene;
    public bool StartingScene;
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "Birmingham")
        {
            BirminghamScene = true;
        }
        if (sceneName == "HuntingPlace")
        {
            HuntingScene = true;
        }
        if (sceneName == "StartingTownScene")
        {
            StartingScene = true;
        }
    }
}
