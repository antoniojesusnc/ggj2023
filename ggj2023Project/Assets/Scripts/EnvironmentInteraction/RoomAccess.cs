using UnityEngine;
using Camera;

namespace EnvironmentInteraction
{
    public class RoomAccess : MonoBehaviour
    {
        [SerializeField]
        private CameraController _roomCameraController;

        // Start is called before the first frame update
        private void OnTriggerEnter()
        {
            CameraManager.Instance.SetCamera(_roomCameraController);
        }

	    /// <summary>
	    /// Visual help to locate the affected area in the editor.
	    /// </summary>
	    private void OnDrawGizmos() {
		    DrawGizmosUtil.Draw(Color.cyan, transform);
		    Gizmos.color = Color.cyan;
		    Gizmos.DrawLine(transform.position, _roomCameraController.transform.position);
	    }
    }
}
