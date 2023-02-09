using System;
using Unity.VisualScripting;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public enum EAudioTrigger
    {
        Enter,
        Exit,
        Stay
    }

    [SerializeField] 
    private EAudioTrigger _when;
    [SerializeField] 
    private AudioTypes _sound;
    [SerializeField] 
    private bool _stopWhenLeave;

    public void OnTriggerEnter(Collider other)
    {
        if (_when == EAudioTrigger.Enter)
        {
            AudioManager.Instance.PlaySound(_sound);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_when == EAudioTrigger.Stay)
        {
            AudioManager.Instance.PlaySound(_sound);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_when == EAudioTrigger.Exit)
        {
            AudioManager.Instance.PlaySound(_sound);
        }

        if (_stopWhenLeave)
        {
            AudioManager.Instance.FinishAudio(_sound);
        }
    }

    private void OnDrawGizmos()
    {
        Color color = Color.magenta;
        DrawGizmosUtil.Draw(color, transform);
    }
}
