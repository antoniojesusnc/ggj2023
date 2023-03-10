using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/CreateItem", order = 1)]
public class ItemInfoConfiguration : ScriptableObject
{
    [field: SerializeField]
    public LocalizationTypes Name { get; private set; }
    
    [field: SerializeField]
    public LocalizationTypes Description { get; private set; }
    
    [field: SerializeField]
    public Sprite Image { get; private set; }
    
    [field: SerializeField]
    public bool IsCollectable { get; private set; }
}
