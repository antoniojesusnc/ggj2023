using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private UIConfiguration _uiConfig;
        
    [SerializeField]
    private float _lastRotation;

    public void OpenDoor()
    {
        transform.DORotate(Vector3.up*_lastRotation, _uiConfig.OpenDoorDelay);
    } 
}
