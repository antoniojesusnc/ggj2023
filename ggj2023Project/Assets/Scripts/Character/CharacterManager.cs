using System;
using Character;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [field: SerializeField] 
    public Transform HeadTransform { get; private set; }

    [field: SerializeField] 
    public CharacterMovementConfiguration _config { get; private set; }
    private void Start()
    {
        GameManager.Instance.OnShakeStatusChanged += OnShakeStatusChanged;
    }

    private void OnShakeStatusChanged(bool shaking)
    {
        GetComponent<AudioListener>().enabled = shaking;

        if (!shaking)
        {
            AudioManager.Instance.PlaySound(AudioTypes.RespiracionAgitada, transform);
            AudioManager.Instance.FinishAudio(AudioTypes.RespiracionAgitada);
        }
    }

    public void InTrigger(ItemDetector itemDetector)
    {
        GetComponent<CharacterItemInteraction>().SetTrigger(itemDetector);
    }
    
    
}
