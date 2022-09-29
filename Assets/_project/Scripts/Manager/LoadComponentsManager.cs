using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadComponentsManager : MonoBehaviour
{
    private const string Menu = "MainMenu";
    private void Start()
    {
        SceneLoaderController.Instance.LoadSceneWithLoading(Menu);
    }
}
