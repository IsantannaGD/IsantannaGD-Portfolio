using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Sequence = DG.Tweening.Sequence;

public class LoadingSceneManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvas;

    [SerializeField] private Image _loadingBarRed;
    [SerializeField] private Image _loadingBarBlue;
    [SerializeField] private Image _loadingBarGreen;
    [SerializeField] private Image _loadingBarFinal;

    [SerializeField] private TextMeshProUGUI _tips;
    [SerializeField] private TextMeshProUGUI _perCenterDisplay;

    [SerializeField] private string[] _phraseTips;
    [SerializeField] private int _phraseTipsIndex;

    private float _perCenterValue;
    private string _sceneName;

    private void Start()
    {
        _canvas.DOFade(1f, 0.5f).OnComplete(() =>
        {
            StartCoroutine(LoadingCoroutine());
        });
    }

    private void Update()
    {
        _perCenterValue =
            ((_loadingBarRed.fillAmount + _loadingBarBlue.fillAmount + _loadingBarGreen.fillAmount) * 100) / 3;
        _perCenterDisplay.text = _perCenterValue + " %";
    }

    private IEnumerator LoadingCoroutine()
    {
        _sceneName = SceneLoaderController.Instance.NextScene;

        Sequence fillBarSequence = DOTween.Sequence();

        fillBarSequence.Append(_loadingBarRed.DOFillAmount(1f, 1.3f).OnComplete(() =>
        {
            _phraseTipsIndex++;
            _tips.text = _phraseTips[_phraseTipsIndex];
        }));
        fillBarSequence.Append(_loadingBarBlue.DOFillAmount(1f, 1.3f).OnComplete(() =>
        {
            _phraseTipsIndex++;
            _tips.text = _phraseTips[_phraseTipsIndex];
        }));
        fillBarSequence.Append(_loadingBarGreen.DOFillAmount(1f, 1.3f).OnComplete(() =>
        {
            StartCoroutine(LoadAsyncOperation());
        }));
        fillBarSequence.Play();

        yield return new WaitForEndOfFrame();
    }

    private IEnumerator LoadAsyncOperation()
    {
        var loadingLevel = SceneManager.LoadSceneAsync(_sceneName);

        while (loadingLevel.progress < 1)
        {
            _loadingBarFinal.fillAmount = loadingLevel.progress;
            yield return new WaitForEndOfFrame();
        }

        if (loadingLevel.isDone)
        {
            _canvas.DOFade(0f, 0.5f);
            yield return new WaitForSeconds(1f);
        }
    }
}
