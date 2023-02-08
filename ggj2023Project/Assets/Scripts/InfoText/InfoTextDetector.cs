using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class InfoTextDetector : MonoBehaviour
{
    [field: SerializeField] 
    public InfoTextConfiguration InfoTextConfig { get; private set; } 
    private void OnTriggerEnter()
    {
        string text = LocalizationManager.Instance.GetText(InfoTextConfig.Text);
        UIInfoText.Instance.ShowText(text);
    }
    
    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(this.transform.position, this.transform.lossyScale);
    }
}
