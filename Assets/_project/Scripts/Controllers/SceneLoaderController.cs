using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderController : MonoBehaviour
{
    public static SceneLoaderController Instance;

    private const string Loading = "LoadingScene";

    public string NextScene { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void LoadSceneWithLoading(string scene)
    {
        NextScene = scene;
        SceneManager.LoadScene(Loading);
    }

    public void LoadScene(string scene)
    {

    }
}
