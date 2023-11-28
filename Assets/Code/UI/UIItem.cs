using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text title;
    [SerializeField] private Button button;
    
    public void SetupItem(GearSet gearSet, Action<GearSet> callback)
    {
        icon.sprite = gearSet.icon;
        title.text = gearSet.gearName;
        button.onClick.AddListener(() => callback(gearSet));
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }
}
