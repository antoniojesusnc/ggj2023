using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        UIGameOver.Instance.ShowEndGameSuccess();
    }
}
