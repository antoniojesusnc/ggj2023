using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    [field: SerializeField] 
    public ItemInfoConfiguration ItemInfoConfig { get; private set; }
    
    [field: SerializeField] 
    public InfoTextConfiguration InfoTextConfig { get; private set; }

    private bool _collected;
    private void OnTriggerEnter()
    {
        if (!_collected)
        {
            GameManager.Instance.Character.InTrigger(this);
        }
        else
        {
            UIInfoText.Instance.ShowText(InfoTextConfig.Text);
        }
    }
    
    private void OnTriggerExit()
    {
        GameManager.Instance.Character.InTrigger(null);
    }

    public void Collect()
    {
        _collected = true;
    }
}
