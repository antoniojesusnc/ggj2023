using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICreditsMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _role2dArtist;

	[SerializeField]
    private TextMeshProUGUI _role3dArtist;

	[SerializeField]
    private TextMeshProUGUI _roleProgramming;

	[SerializeField]
    private TextMeshProUGUI _roleMusic;

	[SerializeField]
    private TextMeshProUGUI _roleGameDesign;

	[SerializeField]
	private TextMeshProUGUI _closeButton;

	[SerializeField]
    private Canvas _canvasMainMenu;

	private void Start () {
		_role2dArtist.text = LocalizationManager.Instance.GetText(LocalizationTypes.CreditsRole2dArtist);
		_role3dArtist.text = LocalizationManager.Instance.GetText(LocalizationTypes.CreditsRole3dArtist);
		_roleProgramming.text = LocalizationManager.Instance.GetText(LocalizationTypes.CreditsRoleProgramming);
		_roleMusic.text = LocalizationManager.Instance.GetText(LocalizationTypes.CreditsRoleMusic);
		_roleGameDesign.text = LocalizationManager.Instance.GetText(LocalizationTypes.CreditsRoleGameDesign);
		_closeButton.text = LocalizationManager.Instance.GetText(LocalizationTypes.MenuClose);
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
