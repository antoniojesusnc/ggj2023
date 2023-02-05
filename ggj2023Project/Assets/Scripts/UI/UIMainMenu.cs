using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _playButton;

	[SerializeField]
    private TextMeshProUGUI _creditsButton;

	[SerializeField]
    private TextMeshProUGUI _exitButton;

	private void Start () {
		_playButton.text = LocalizationManager.Instance.GetText(LocalizationTypes.MenuPlay);
		_creditsButton.text = LocalizationManager.Instance.GetText(LocalizationTypes.MenuCredits);
		_exitButton.text = LocalizationManager.Instance.GetText(LocalizationTypes.MenuExit);
	}

	private void Update() {
        		// Pressed Sscape
		if (Input.GetKeyDown(KeyCode.Escape)) {
			// Close game
            CloseGame();
		}
	}

	public void OnClickOnPlay()
    {
        SceneManager.LoadScene((int)GameScenes.MainScene);
    }

    public void OnClickOnCredits()
    {
        SceneManager.LoadScene((int)GameScenes.MainScene);
    }

    public void OnClickOnExit()
    {
        CloseGame();
    }

    public void CloseGame() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#elif !UNITY_WEBGL
		Application.Quit();
#endif
	}
}
