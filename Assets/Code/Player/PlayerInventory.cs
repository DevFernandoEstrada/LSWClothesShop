using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static event Action<ItemCategory, GearSet> OnGearSetChanged;

    public GearSet basic, emptyBody, emptyHead;

    public List<GearSet> gearSets;
    private readonly Dictionary<ItemCategory, GearSet> _equippedGear = new();

    private void Start()
    {
        SetupGear();
    }

    private void SetupGear()
    {
        _equippedGear.Add(ItemCategory.Base, emptyBody);
        _equippedGear.Add(ItemCategory.Head, emptyBody);
        _equippedGear.Add(ItemCategory.Body, emptyBody);

        ChangeGearSet(basic);
    }

    public void AddGearSet(GearSet newGearSet)
    {
        gearSets.Add(newGearSet);
    }
    
    public void RemoveGearSet(GearSet removeGearSet)
    {
        if (removeGearSet == _equippedGear[removeGearSet.category])
        {
            ChangeGearSet(removeGearSet.category == ItemCategory.Body ? emptyBody : emptyHead);
        }
        gearSets.Remove(removeGearSet);
    }

    private void ChangeGearSet(GearSet gearSet)
    {
        _equippedGear[gearSet.category] = gearSet;
        OnGearSetChanged?.Invoke(gearSet.category, gearSet);
        UIManager.Instance.HideItems();
    }

    public Stats GetEquippedStats()
    {
        Stats currentStats = default;
        foreach (KeyValuePair<ItemCategory, GearSet> gearSet in _equippedGear)
        {
            currentStats.SumStats(gearSet.Value.stats);
        }

        return currentStats;
    }
    
    public void OpenInventory()
    {
        UIItemsData uiItemsData;
        uiItemsData.header = "Inventory";
        uiItemsData.leftPanel = "Body";
        uiItemsData.rightPanel = "Head";
        uiItemsData.leftGearSet = gearSets.Where(gearSet => gearSet.category == ItemCategory.Body).ToList();
        uiItemsData.rightGearSet = gearSets.Where(gearSet => gearSet.category == ItemCategory.Head).ToList();
        uiItemsData.leftCallback = ChangeGearSet;
        uiItemsData.rightCallback = ChangeGearSet;
        
        UIManager.Instance.ShowItems(uiItemsData);
        Player.Instance.movement.EnableMovement(false);
    }
}