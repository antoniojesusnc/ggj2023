using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICreditsMenu : MonoBehaviour
{
    /*[SerializeField]
    private TextMeshProUGUI _playButton;

	[SerializeField]
    private TextMeshProUGUI _creditsButton;

	[SerializeField]
    private TextMeshProUGUI _exitButton;*/

	[SerializeField]
    private Canvas _canvasMainMenu;

	private void Start () {
		/*_playButton.text = LocalizationManager.Instance.GetText(LocalizationTypes.MenuPlay);
		_creditsButton.text = LocalizationManager.Instance.GetText(LocalizationTypes.MenuCredits);
		_exitButton.text = LocalizationManager.Instance.GetText(LocalizationTypes.MenuExit);*/
	}

	private void Update() {
		// Pressed Scape --> Close the canvas
		if (Input.GetKeyDown(KeyCode.Escape)) {
			CloseCanvas();
		}
	}

	public void OnClickOnClose()
    {
		CloseCanvas();
	}

    public void CloseCanvas() {
		// Enable main menu canvas
		_canvasMainMenu.gameObject.SetActive(true);
		// Disable this canvas
		gameObject.SetActive(false);
	}
}
