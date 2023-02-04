using UnityEngine;

public class UIDiary : Singleton<UIDiary>
{
    [SerializeField] private UIItemToShow _itemToShow;
    [SerializeField] private UIItemElement _itemElementPrefab;
    [SerializeField] private GameObject _canvas;
    
    public void OpenInventory()
    {
        var itemsCollected = GameManager.Instance.ItemsCollected;

        for (int i = 0; i < itemsCollected.Count; i++)
        {
            Instantiate<UIItemElement>(_itemElementPrefab);
        }
    }
    
    public void OpenItem(ItemInfoConfiguration itemToInteract)
    {
        _canvas.gameObject.SetActive(true);
        _itemToShow.gameObject.SetActive(true);
        _itemToShow.Open(itemToInteract);
    }

    public void Close()
    {
        if (_itemToShow.isActiveAndEnabled)
        {
            _itemToShow.gameObject.SetActive(false);
        }
        _canvas.gameObject.SetActive(false);
    }
}
