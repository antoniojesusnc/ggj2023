using Camera;
using UnityEngine;

public class EnemyBillBoard : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(CameraManager.Instance.ActiveCamera.transform);
    }
}
