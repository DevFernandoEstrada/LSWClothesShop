using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] public Button inventoryButton;

    private void Start()
    {
        inventoryButton.onClick.AddListener(() => Player.Instance.inventory.OpenInventory());
    }
}