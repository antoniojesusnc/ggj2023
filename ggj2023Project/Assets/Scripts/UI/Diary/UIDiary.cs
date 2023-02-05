using UnityEngine;

public class UIDiary : Singleton<UIDiary>
{
    [SerializeField] private UIItemToShow _itemToShow;
    [SerializeField] private UIItemElement _itemElementPrefab;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Transform _fullInventory;

    public bool IsOpened { get; private set; }

    void Awake()
    {
        _canvas.gameObject.SetActive(false);
    }
    
    [ContextMenu("OpenInventory")]
    public void OpenInventory()
    {
        var itemsCollected = GameManager.Instance.ItemsCollected;

        for (int i = 0; i < itemsCollected.Count; i++)
        {
            var item = Instantiate<UIItemElement>(_itemElementPrefab, _fullInventory);
            item.SetData(itemsCollected[i]);
        }
        
        
        
        _canvas.gameObject.SetActive(true);
        _itemToShow.gameObject.SetActive(false);
        
        IsOpened = true;
    }

    public void OpenItem(UIItemElement item)
    {
        OpenItem(item.ItemConfig);   
    }
    
    public void OpenItem(ItemInfoConfiguration itemToInteract)
    {
        _canvas.gameObject.SetActive(true);
        _itemToShow.gameObject.SetActive(true);
        _itemToShow.Open(itemToInteract);

        IsOpened = true;
    }

    public void Close()
    {
        _itemToShow.gameObject.SetActive(false);
        _canvas.gameObject.SetActive(false);
        IsOpened = false;
    }

    void Update()
    {
        if (IsOpened && Input.GetKeyDown(KeyCode.Space))
        {
            Close();
        }
        
        if (!IsOpened && Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }
    }
}
