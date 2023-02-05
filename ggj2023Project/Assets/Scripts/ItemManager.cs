using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] private bool _hasKeyFake;
    
    private int _index;
    [SerializeField]
    private List<ItemInfoConfiguration> _itemInfoConfig;

    [SerializeField] public bool HasKey => _hasKeyFake || GameManager.Instance.ItemsCollected.Exists(item => item.Name == LocalizationTypes.Llave);
    
    void Start()
    {
        _index = 0;
    }

    public ItemInfoConfiguration GetNextDiary(ItemDetector itemToInteract)
    {
        return itemToInteract.ItemInfoConfig;
        if (_index < _itemInfoConfig.Count)
        {
            return _itemInfoConfig[_index++];
        }
        return _itemInfoConfig[_itemInfoConfig.Count-1];
    }
}
