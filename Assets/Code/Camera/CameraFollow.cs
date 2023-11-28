using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;
    
    public Transform toFollow;
    private Camera _camera;

    private void Awake()
    {
        Instance = this;
        _camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        Vector3 position = toFollow.position;
        transform.position = new Vector3(position.x, position.y, -10);
    }

    public Camera GetCamera()
    {
        return _camera;
    }
}
