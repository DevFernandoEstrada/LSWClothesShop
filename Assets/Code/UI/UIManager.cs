using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private UIMessage uiMessage;
    [SerializeField] private UIItemDescription uiItemDescriptionPrefab;
    [SerializeField] private UIItems uiItemsPrefab;
    private UIItems _uiItemsInstance;

    [SerializeField] private GameObject uIDashboard;

    private void Awake()
    {
        Instance = this;
        // SetupUICanvases();
    }

    // private void SetupUICanvases()
    // {
    //     
    //     HideItems();
    // }

    public void ShowItems(UIItemsData uiItemsData)
    {
        if (_uiItemsInstance == null)
        {
            _uiItemsInstance = Instantiate(uiItemsPrefab, transform);
        }
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

    public void ShowItemDescription(GearSet gearSet, string overrideValue, string actionButtonText, Action<GearSet> callback = null)
    {
        Instantiate(uiItemDescriptionPrefab).Setup(gearSet, overrideValue, actionButtonText, callback);
    }
    
    public void ShowMessage(string header, string message, string actionButtonText, Action callback = null)
    {
        Instantiate(uiMessage).Setup(header, message, actionButtonText, callback);
    }
}