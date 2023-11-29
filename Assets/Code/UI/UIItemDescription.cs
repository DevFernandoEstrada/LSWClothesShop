using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemDescription : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTitle;
    [SerializeField] private TMP_Text txtDescription;
    [SerializeField] private TMP_Text txtValue;
    [SerializeField] private TMP_Text txtRarity;
    [SerializeField] private TMP_Text txtButton;
    [SerializeField] private Image icon;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button actionButton;

    private void Start()
    {
        closeButton.onClick.AddListener(CloseItemDescription);
    }

    public void Setup(GearSet gearSet, string overrideValue, string actionButtonText, Action<GearSet> callback = null)
    {
        txtTitle.text = gearSet.gearName;
        txtDescription.text = $"{gearSet.description}\n\nHealth + {gearSet.stats.health}\nSpeed + {gearSet.stats.speed}";
        txtValue.text = $"Value {overrideValue}";
        txtRarity.text = gearSet.rarity.ToString();
        txtButton.text = actionButtonText;
        icon.sprite = gearSet.icon;
        if (callback != null)
        {
            actionButton.onClick.AddListener(() =>
            {
                callback(gearSet);
                CloseItemDescription();
            });
        }
        else
        {
            actionButton.onClick.AddListener(CloseItemDescription);
        }
    }

    private void CloseItemDescription()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        actionButton.onClick.RemoveAllListeners();
        closeButton.onClick.RemoveAllListeners();
    }
}