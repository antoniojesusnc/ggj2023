using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmosUtil
{
    public static void Draw(Color color, Transform transform)
    {
        Gizmos.color = color;
        var lossyScale = transform.lossyScale;
        var colliderSize = transform.GetComponent<BoxCollider>().size;
        Vector3 size = new Vector3(
            lossyScale.x * colliderSize.x,
            lossyScale.y * colliderSize.y,
            lossyScale.z * colliderSize.z
        );
        
        Gizmos.DrawWireCube(transform.position, size);
    }
}
