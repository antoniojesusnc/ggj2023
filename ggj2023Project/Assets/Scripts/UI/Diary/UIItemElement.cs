using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _image;

    public ItemInfoConfiguration ItemConfig { get; private set; }

    public void OnClick()
    {
        UIDiary.Instance.OpenItem(this);
    }

    public void SetData(ItemInfoConfiguration itemConfig)
    {
        ItemConfig = itemConfig;
        _text.SetText(ItemConfig.Name);
        _image.sprite = ItemConfig.Image;
    }
}
