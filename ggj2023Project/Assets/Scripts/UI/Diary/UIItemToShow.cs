using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemToShow : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI _tittle;
    [SerializeField] 
    private Image _image;
    [SerializeField] 
    private UISlowText _slowText;
    
    public void Open(ItemInfoConfiguration itemToInteract)
    {
        _tittle.SetText(LocalizationManager.Instance.GetTittleText(itemToInteract.Name));
        _image.sprite = itemToInteract.Image;
        _slowText.SetText(LocalizationManager.Instance.GetText(itemToInteract.Description), false);
    }
}
