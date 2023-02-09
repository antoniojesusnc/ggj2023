using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] private ItemInfoConfiguration _key;
    
    [SerializeField] private bool _hasKeyFake;
    
    [SerializeField] private int _numItemsToGetKey;

    [field:SerializeField]
    public List<ItemInfoConfiguration> ItemsCollected { get; private set; } = new();

    [SerializeField] public bool HasKey => _hasKeyFake || ItemsCollected.Exists(item => item.Name == LocalizationTypes.Llave);
    

    public void CollectItem(ItemInfoConfiguration nextItem)
    {
        ItemsCollected.Add(nextItem);

        
        if (ItemsCollected.Count >= _numItemsToGetKey && !HasKey)
        {
            AddKey();
        }
        ItemsCollected.Sort(SortByName);
    }

    private void AddKey()
    {
        ItemsCollected.Add(_key);
        AudioManager.Instance.PlaySound(AudioTypes.Llave);
    }

    private int SortByName(ItemInfoConfiguration x, ItemInfoConfiguration y)
    {
        return x.Name.CompareTo(y.Name);
    }
}
