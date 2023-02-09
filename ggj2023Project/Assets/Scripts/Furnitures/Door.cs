using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private UIConfiguration _uiConfig;
        
    [SerializeField]
    private float _lastRotation;
    
    [SerializeField]
    private Transform _door;

    private float _originalRotation;

    private void OnTriggerEnter()
    {
        if (ItemManager.Instance.HasKey)
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (ItemManager.Instance.HasKey)
        {
            CloseDoor();
        }
    }

    public void OpenDoor()
    {
        _originalRotation = transform.eulerAngles.y;
        _door.DORotate(Vector3.up*_lastRotation, _uiConfig.OpenDoorDelay);
        AudioManager.Instance.PlaySound(AudioTypes.PuertaAbriendose);
    }
    
    public void CloseDoor()
    {
        _door.DORotate(Vector3.up*_originalRotation, _uiConfig.OpenDoorDelay);
        AudioManager.Instance.PlaySound(AudioTypes.PuertaCerrandose);
        GetComponent<Collider>().enabled = false;
    } 
}
