using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class UIGameOver : Singleton<UIGameOver>
{
    [SerializeField] 
    private UIConfiguration _uIConfig;
    
    [SerializeField]
    private CanvasGroup _canvasGroupGameOver;
    
    [Header("Success")]
    [SerializeField]
    private CanvasGroup _canvasGroupGameOverSuccess;
    
    [SerializeField]
    private UISlowText victoryMessage;
    
    [SerializeField]
    private GameObject _playAgainButton;

    [SerializeField]
    public bool IsGameOver { get; private set; }
    
    void Start()
    {
        
        GameManager.Instance.OnGameOver += OnGameOver;
        _canvasGroupGameOver.alpha = 0;
        _canvasGroupGameOver.GetComponent<Canvas>().gameObject.SetActive(false);
        _canvasGroupGameOverSuccess.alpha = 0;
        _canvasGroupGameOverSuccess.GetComponent<Canvas>().gameObject.SetActive(false);
    }

    private void OnGameOver()
    {
        IsGameOver = true;
        _canvasGroupGameOver.GetComponent<Canvas>().gameObject.SetActive(true);
        _canvasGroupGameOver.DOFade(1, _uIConfig.GameOverFadeTime);
    }

    public void OnClickInPlayAgainButton()
    {
        _canvasGroupGameOver.DOFade(0, _uIConfig.GameOverFadeTime).onComplete += () => OnPlayAgain();
    }

    private void OnPlayAgain()
    {
        _canvasGroupGameOver.GetComponent<Canvas>().gameObject.SetActive(false);
        GameManager.Instance.PlayAgain();
        IsGameOver = false;
    }

    public void ShowEndGameSuccess()
    {
        IsGameOver = true;
        _canvasGroupGameOverSuccess.gameObject.SetActive(true);
        _canvasGroupGameOverSuccess.GetComponent<Canvas>().gameObject.SetActive(true);
        _canvasGroupGameOverSuccess.DOFade(1, _uIConfig.GameOverFadeTime);
        victoryMessage.SetText(LocalizationManager.Instance.GetText(LocalizationTypes.final_scene), false);
        
        _playAgainButton.SetActive(false);
        victoryMessage.OnFinishText += () => _playAgainButton.SetActive(true);
    }

    public void OnClickInRestart()
    {
        IsGameOver = false;
        SceneManager.LoadScene((int)GameScenes.LoadingScene);
        
    }
}
