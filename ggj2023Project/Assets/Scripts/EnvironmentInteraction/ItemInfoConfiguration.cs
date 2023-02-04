using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/CreateItem", order = 1)]
public class ItemInfoConfiguration : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; private set; }
    
    [field: SerializeField]
    public string Description { get; private set; }
    
    [field: SerializeField]
    public Sprite Image { get; private set; }
    
    [field: SerializeField]
    public bool Collectable { get; private set; }
}
