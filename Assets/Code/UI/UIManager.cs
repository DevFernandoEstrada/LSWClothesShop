using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private UIItems uiItemsPrefab;
    private UIItems _uiItemsInstance;

    [SerializeField] private GameObject uIDashboard;

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
        uIDashboard.SetActive(false);
    }

    public void HideItems()
    {
        _uiItemsInstance.CloseUIItems();
        uIDashboard.SetActive(true);
    }

    public void RefreshItems()
    {
        _uiItemsInstance.Refresh();
    }
}