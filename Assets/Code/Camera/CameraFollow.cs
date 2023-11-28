using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform toFollow;

    private void LateUpdate()
    {
        Vector3 position = toFollow.position;
        transform.position = new Vector3(position.x, position.y, -10);
    }
}
