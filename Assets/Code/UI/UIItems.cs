using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItems : MonoBehaviour
{
    [SerializeField] private TMP_Text txtHeader;
    [SerializeField] private TMP_Text[] txtLeftPanel;
    [SerializeField] private TMP_Text[] txtRightPanel;
    [SerializeField] private Button leftButtonPanel;
    [SerializeField] private Button closePanel;
    [SerializeField] private Transform leftPanelItemsPlace, rightPanelItemsPlace;
    [SerializeField] private UIItem uiItemPrefab;

    private UIItemsData _currentData;

    private void Start()
    {
        closePanel.onClick.AddListener(() => UIManager.Instance.HideItems());
    }

    public void CloseUIItems()
    {
        leftButtonPanel.onClick.Invoke();
        DestroyAllItems();
        Player.Instance.movement.EnableMovement(true);
        gameObject.SetActive(false);
    }

    public void Refresh()
    {
        DestroyAllItems();
        EnableUIItems(_currentData);
    }

    public void EnableUIItems(UIItemsData uiItemsData)
    {
        _currentData = uiItemsData;
        gameObject.SetActive(true);
        txtHeader.text = uiItemsData.header;
        SetPanelText(txtLeftPanel, uiItemsData.leftPanel);
        SetPanelText(txtRightPanel, uiItemsData.rightPanel);
        CreateItems(leftPanelItemsPlace, uiItemsData.leftGearSet, uiItemsData.leftCallback);
        CreateItems(rightPanelItemsPlace, uiItemsData.rightGearSet, uiItemsData.rightCallback);
    }

    private void CreateItems(Transform place, List<GearSet> gearSets, Action<GearSet> callback)
    {
        foreach (GearSet gearSet in gearSets)
        {
            Instantiate(uiItemPrefab, place).SetupItem(gearSet, callback);
        }
    }

    private void DestroyAllItems()
    {
        foreach (Transform item in leftPanelItemsPlace.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in rightPanelItemsPlace.transform)
        {
            Destroy(item.gameObject);
        }
    }

    private void SetPanelText(TMP_Text[] sidePanel, string textPanel)
    {
        foreach (TMP_Text panelText in sidePanel)
        {
            panelText.text = textPanel;
        }
    }
}