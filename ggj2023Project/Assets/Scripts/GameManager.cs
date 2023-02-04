using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField]
    public float Intensity { get; private set; }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
    }
}
