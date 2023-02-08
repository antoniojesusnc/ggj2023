using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (ItemManager.Instance.HasKey)
        {
            GameManager.Instance.GameOverSuccess();
            UIGameOver.Instance.ShowEndGameSuccess();
        }
        else
        {
            UIInfoText.Instance.ShowText(LocalizationManager.Instance.GetTittleText(LocalizationTypes.CannotFinish));
        }
    }
}
