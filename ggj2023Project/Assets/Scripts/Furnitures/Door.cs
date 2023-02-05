using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private UIConfiguration _uiConfig;
        
    [SerializeField]
    private float _lastRotation;
    
    [SerializeField]
    private Transform _door;

    private void OnTriggerEnter()
    {
        if (ItemManager.Instance.HasKey)
        {
            OpenDoor();
        }
    }
    public void OpenDoor()
    {
        _door.DORotate(Vector3.up*_lastRotation, _uiConfig.OpenDoorDelay);
    } 
}
