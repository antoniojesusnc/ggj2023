using System.Collections.Generic;
using UnityEngine;

public class CharacterSteps : MonoBehaviour
{
    [SerializeField] 
    private CharacterMovementConfiguration _characterMovementConfig;
    
    [SerializeField]
    private List<AudioTypes> _stepSounds = new List<AudioTypes>()
    {
        AudioTypes.Paso00,
        AudioTypes.Paso01,
        AudioTypes.Paso02,
        AudioTypes.Paso03,
        AudioTypes.Paso04,
        AudioTypes.Paso05,
        AudioTypes.Paso06,
        AudioTypes.Paso07,
        AudioTypes.Paso08,
        AudioTypes.Paso09,
    };

    private AudioTypes _lastStepType;

    private float _timestamp;
    
    public void IsWalkingForward(bool runPressed)
    {
        if (CanPlaySound())
        {
            PlaySound(runPressed
                          ? _characterMovementConfig.RunningStepDuration
                          : _characterMovementConfig.ForwardStepDuration);
        }
    }

    public void IsWalkingBackward()
    {
        if (CanPlaySound())
        {
            PlaySound(_characterMovementConfig.BackwardStepDuration);
        }
    }

    public void IsRotating()
    {
        if (CanPlaySound())
        {
            PlaySound(_characterMovementConfig.RotateStepDuration);
        }
    }


    public void IsNotWalking()
    {
        AudioManager.Instance.DestroyAudioSourceAfter(_lastStepType, 0);
    }
    private bool CanPlaySound()
    {
        return _timestamp <= 0;
    }
    
    private void PlaySound(float stepDuration)
    {
        _timestamp = stepDuration;
        _lastStepType = GetRandomStep();
        AudioManager.Instance.PlaySound(_lastStepType, transform);
        AudioManager.Instance.DestroyAudioSourceAfter(_lastStepType, stepDuration);
    }

    void Update()
    {
        _timestamp = Mathf.Clamp(_timestamp-Time.deltaTime, 0, float.MaxValue);
    }
    
    public AudioTypes GetRandomStep()
    {
        int step = Random.Range(0, _stepSounds.Count);
        return _stepSounds[step];
    }
}
