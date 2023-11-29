using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrateView : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Button openCrate;

    private Crate _controller;
    
    private void Start()
    {
        SetCameraOnCanvas();
        _controller = GetComponent<Crate>();
        openCrate.onClick.AddListener(_controller.OpenCrate);
    }

    private void OnDestroy()
    {
        openCrate.onClick.RemoveAllListeners();
    }

    private void SetCameraOnCanvas()
    {
        canvas.worldCamera = CameraFollow.Instance.GetCamera();
    }

    public void EnableUIButton(bool enable)
    {
        canvas.gameObject.SetActive(enable);
    }
}
