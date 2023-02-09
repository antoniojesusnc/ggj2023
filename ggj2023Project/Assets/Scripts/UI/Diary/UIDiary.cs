using UnityEngine;

public class UIDiary : Singleton<UIDiary>
{
    [SerializeField] private UIItemToShow _itemToShow;
    [SerializeField] private UIItemElement _itemElementPrefab;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Transform _fullInventory;

    public bool IsOpened => _isItemOpened || _isInventoryOpened;
    private bool _isItemOpened;
    private bool _isInventoryOpened;

    private bool _keyGet;
    
    void Awake()
    {
        _canvas.gameObject.SetActive(false);
    }
    
    [ContextMenu("OpenInventory")]
    public void OpenInventory()
    {
        var itemsCollected = ItemManager.Instance.ItemsCollected;

        for (int i = 0; i < itemsCollected.Count; i++)
        {
            var item = Instantiate<UIItemElement>(_itemElementPrefab, _fullInventory);
            item.SetData(itemsCollected[i]);
        }
        
        _canvas.gameObject.SetActive(true);
        _itemToShow.gameObject.SetActive(false);
        
        _isInventoryOpened = true;
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

        _isItemOpened = true;
    }

    public void Close()
    {
        _itemToShow.gameObject.SetActive(false);
        if (_isInventoryOpened && _isItemOpened)
        {
            _isItemOpened = false;
            return;
        }

        if (!_keyGet)
        {
            if (ItemManager.Instance.HasKey)
            {
                OpenItem(ItemManager.Instance.ItemsCollected.Find(item => item.Name == LocalizationTypes.Llave));
                _keyGet = true;
                return;
            }
        }
        
        _canvas.gameObject.SetActive(false);
        // Remove all the elements in the inventory
        foreach (UIItemElement item in _fullInventory.gameObject.GetComponentsInChildren<UIItemElement>())
        {
            Destroy(item.gameObject);
        }

        _isInventoryOpened = false;
        _isItemOpened = false;
        AudioManager.Instance.PlaySound(AudioTypes.CerrarDiario);
    }

    void Update()
    {
        if (IsOpened && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape)))
        {
            Close();
            return;
        }
        
        if (!IsOpened && Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }
    }
}
