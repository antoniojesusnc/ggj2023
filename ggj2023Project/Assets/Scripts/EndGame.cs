using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.HasItem07)
        {
            UIGameOver.Instance.ShowEndGameSuccess();
        }
        else
        {
            UIInfoText.Instance.ShowText(LocalizationManager.Instance.GetTittleText(LocalizationTypes.CannotFinish));
        }
    }
}
