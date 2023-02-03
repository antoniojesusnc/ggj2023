using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public void OnClickOnPlay()
    {
        SceneManager.LoadScene((int)GameScenes.MainScene);
    }
}
