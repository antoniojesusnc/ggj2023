using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/CreateInfoText", order = 1)]
public class InfoTextConfiguration : ScriptableObject
{
    [field: SerializeField]
    public LocalizationTypes Text { get; private set; }
    
    [field: SerializeField]
    public bool Repeatable { get; private set; }
}
