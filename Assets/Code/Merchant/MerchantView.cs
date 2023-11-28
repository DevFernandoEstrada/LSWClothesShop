using UnityEngine;
using UnityEngine.UI;

public class MerchantView : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Button buy;

    private Merchant _controller;
    
    private void Start()
    {
        SetCameraOnCanvas();
        _controller = GetComponent<Merchant>();
        buy.onClick.AddListener(_controller.OpenStore);
    }

    private void OnDestroy()
    {
        buy.onClick.RemoveAllListeners();
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
