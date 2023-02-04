using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameOver : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _canvasGroup;

    [SerializeField] private UIConfiguration _uIConfig;
    void Start()
    {
        GameManager.Instance.OnGameOver += OnGameOver;
        _canvasGroup.alpha = 0;
    }

    private void OnGameOver()
    {
        _canvasGroup.DOFade(1, _uIConfig.GameOverFadeTime);
    }

    public void OnClickInPlayAgainButton()
    {
        SceneManager.LoadScene((int)GameScenes.LoadingScene);
    }
}
