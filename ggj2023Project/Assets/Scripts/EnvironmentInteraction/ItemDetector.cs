using EnvironmentInteraction;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ItemDetector : MonoBehaviour
{
    [field: SerializeField] 
    public ItemInfoConfiguration ItemInfoConfig { get; private set; }
    
    [field: SerializeField] 
    public InfoTextConfiguration InfoTextConfig { get; private set; }

    [SerializeField] 
    private AudioTypes _audioWhenInteract;

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
            return;
            if (InfoTextConfig.Text != LocalizationTypes.None)
            {
                UIInfoText.Instance.ShowText(LocalizationManager.Instance.GetText(InfoTextConfig.Text));
            }
        }
    }

    void Update()
    {
        if (IsCollected)
        {
            GetComponentInChildren<Beam>().gameObject.SetActive(false);
            enabled = false;
        }
    }
    
    private void OnTriggerExit()
    {
        CanBeTriggered = false;
        GameManager.Instance.Character.InTrigger(null);
        UITriggerInput.Instance.ShowSpace(false);
    }

    public void Interact()
    {
        if (ItemInfoConfig.IsCollectable)
        {
            ItemManager.Instance.CollectItem(ItemInfoConfig);
            IsCollected = true;
        }
        AudioManager.Instance.PlaySound(_audioWhenInteract, transform);
    }
    
    private void OnDrawGizmos()
    {
        DrawGizmosUtil.Draw(Color.blue, transform);
        
    }
}
