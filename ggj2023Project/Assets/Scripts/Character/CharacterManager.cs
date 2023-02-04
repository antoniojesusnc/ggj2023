using Character;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [field: SerializeField] 
    public Transform HeadTransform { get; private set; }

    public void InTrigger(ItemDetector itemDetector)
    {
        GetComponent<CharacterItemInteraction>().SetTrigger(itemDetector);
    }
}
