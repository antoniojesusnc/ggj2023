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
    
    private bool _collected;
    private void OnTriggerEnter()
    {
        CanBeTriggered = true;
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
        CanBeTriggered = false;
        GameManager.Instance.Character.InTrigger(null);
    }

    public void Collect()
    {
        _collected = true;
    }
}
