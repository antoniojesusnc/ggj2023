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
        _canvasGroup.GetComponent<Canvas>().gameObject.SetActive(false);
    }

    private void OnGameOver()
    {
        _canvasGroup.GetComponent<Canvas>().gameObject.SetActive(true);
        _canvasGroup.DOFade(1, _uIConfig.GameOverFadeTime);
    }

    public void OnClickInPlayAgainButton()
    {
        _canvasGroup.DOFade(0, _uIConfig.GameOverFadeTime).onComplete += () => OnPlayAgain();
    }

    private void OnPlayAgain()
    {
        _canvasGroup.GetComponent<Canvas>().gameObject.SetActive(false);
        GameManager.Instance.PlayAgain();
    }
}
