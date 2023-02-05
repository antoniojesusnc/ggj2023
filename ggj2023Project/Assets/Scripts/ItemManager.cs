using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField]
    private List<ItemInfoConfiguration> _itemInfoConfig;
}
