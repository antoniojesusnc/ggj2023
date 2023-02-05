using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ItemDetector : MonoBehaviour
{
    [field: SerializeField] 
    public ItemInfoConfiguration ItemInfoConfig { get; private set; }
    
    [field: SerializeField] 
    public InfoTextConfiguration InfoTextConfig { get; private set; }

    [field: SerializeField] 
    public bool CanBeTriggered { get; private set; }
    public bool IsCollected { get; private set; }
    
    private void OnTriggerEnter()
    {
        CanBeTriggered = true;
        if (!IsCollected)
        {
            GameManager.Instance.Character.InTrigger(this);
            UITriggerInput.Instance.ShowSpace(true);
        }
        else
        {
            if (InfoTextConfig.Text != LocalizationTypes.None)
            {
                UIInfoText.Instance.ShowText(LocalizationManager.Instance.GetText(InfoTextConfig.Text));
            }
        }
    }
    
    private void OnTriggerExit()
    {
        CanBeTriggered = false;
        GameManager.Instance.Character.InTrigger(null);
        UITriggerInput.Instance.ShowSpace(false);
    }

    public void Collect()
    {
        IsCollected = true;
    }
}
