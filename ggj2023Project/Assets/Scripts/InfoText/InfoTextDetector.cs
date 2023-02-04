using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class InfoTextDetector : MonoBehaviour
{
    [field: SerializeField] 
    public InfoTextConfiguration InfoTextConfig { get; private set; } 
    private void OnTriggerEnter()
    {
        UIInfoText.Instance.ShowText(InfoTextConfig.Text);
    }
    
   
}
