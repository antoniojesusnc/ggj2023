using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    [field: SerializeField] 
    public ItemInfoConfiguration ItemInfoConfig { get; private set; } 
    private void OnTriggerEnter()
    {
        GameManager.Instance.Character.InTrigger(this);
    }
    
    private void OnTriggerExit()
    {
        GameManager.Instance.Character.InTrigger(null);
    }
}
