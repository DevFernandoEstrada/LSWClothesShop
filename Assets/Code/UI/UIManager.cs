using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private UIItems uiItemsPrefab;
    private UIItems _uiItemsInstance;

    private void Awake()
    {
        Instance = this;
        SetupUICanvases();
    }

    private void SetupUICanvases()
    {
        _uiItemsInstance = Instantiate(uiItemsPrefab, transform);
        HideItems();
    }

    public void ShowItems(UIItemsData uiItemsData)
    {
        _uiItemsInstance.EnableUIItems(uiItemsData);
    }

    public void HideItems()
    {
        _uiItemsInstance.gameObject.SetActive(false);
    }

    public void RefreshItems()
    {
        _uiItemsInstance.Refresh();
    }
}
