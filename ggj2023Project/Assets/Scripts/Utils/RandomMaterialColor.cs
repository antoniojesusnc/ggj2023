using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterialColor : MonoBehaviour
{
    void Start()
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.color = Random.ColorHSV();
    }

    
}
