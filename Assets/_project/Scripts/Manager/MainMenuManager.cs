using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public delegate void MainMenuGeneralEventHandler();
    public MainMenuGeneralEventHandler onSceneInitialize;

    [Header("** Settings Controllers **")]
    [Space]
    [SerializeField] private GraphicSettings _graphics;
    [SerializeField] private AudioSettings _audio;
    [SerializeField] private LanguageSettings _language;
    [SerializeField] private ControlSettings _control;

    [Header("** Buttons **")]
    [Space]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _exitButton;

    [Header("** Components **")]
    [Space]
    [SerializeField] private GameObject _firstPanel;
    [SerializeField] private GameObject _secondPanel;

    [Header("** Variable **")]
    [Space]
    [SerializeField] private float _openFirstPanelSpeed;

    private void Start()
    {
        /*
        _graphics.Initialize();
        _audio.Initialize();
        _language.Initialize();
        _control.Initialize();
        */

        _playButton.onClick.AddListener(OpenPlayPanel);
        _settingsButton.onClick.AddListener(OpenSettingsPanel);
        _creditsButton.onClick.AddListener(OpenCreditsPanel);
        _resumeButton.onClick.AddListener(OpenResumePanel);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void OpenPlayPanel()
    {
        FirstPanelOpenCloseAnim();
    }

    private void OpenSettingsPanel()
    {
        FirstPanelOpenCloseAnim();
    }

    private void OpenCreditsPanel()
    {
        FirstPanelOpenCloseAnim();
    }

    private void OpenResumePanel()
    {
        FirstPanelOpenCloseAnim();
    }

    private void ExitGame()
    {
#if UNITY_EDITOR

UnityEditor.EditorApplication.isPlaying = false;        
return;

#endif
        Application.Quit();
    }

    private void FirstPanelOpenCloseAnim()
    {
        if (!_firstPanel.activeSelf)
        {
            _firstPanel.SetActive(true);
            _firstPanel.transform.DOScaleX(1f, _openFirstPanelSpeed);
        }
        else
        {
            _firstPanel.transform.DOScaleX(0f, _openFirstPanelSpeed).OnComplete(() => _firstPanel.SetActive(false));
        }
    }
}
