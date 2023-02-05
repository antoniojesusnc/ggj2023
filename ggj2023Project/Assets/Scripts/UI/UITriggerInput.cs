using UnityEngine;

public class UITriggerInput : Singleton<UITriggerInput>
{
    [SerializeField] 
    private GameObject _spaceImage;

    void Awake()
    {
        ShowSpace(false);
    }
    
    public void ShowSpace(bool show)
    {
        _spaceImage.SetActive(show);
    }
}
