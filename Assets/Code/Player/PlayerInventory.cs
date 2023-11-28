using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static event Action<ItemCategory, GearSet> OnGearSetChanged;

    public GearSet basic, empty;

    public List<GearSet> gearSets;
    private readonly Dictionary<ItemCategory, GearSet> _equippedGear = new();

    private void Start()
    {
        SetupGear();
    }

    private void SetupGear()
    {
        _equippedGear.Add(ItemCategory.Base, empty);
        _equippedGear.Add(ItemCategory.Head, empty);
        _equippedGear.Add(ItemCategory.Body, empty);

        ChangeGearSet(ItemCategory.Base, basic);
    }

    public void AddGearSet(GearSet newGearSet)
    {
        gearSets.Add(newGearSet);
    }
    
    public void RemoveGearSet(GearSet removeGearSet)
    {
        if (removeGearSet == _equippedGear[removeGearSet.category])
        {
            ChangeGearSet(removeGearSet.category, empty);
        }
        gearSets.Remove(removeGearSet);
    }

    private int _currentGear;
    
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        _currentGear++;
        if (_currentGear >= gearSets.Count)
        {
            _currentGear = 0;
        }

        if (gearSets.Count > 0)
        {
            ChangeGearSet(gearSets[_currentGear].category, gearSets[_currentGear]);
        }
    }

    private void ChangeGearSet(ItemCategory category, GearSet gearSet)
    {
        _equippedGear[category] = gearSet;
        OnGearSetChanged?.Invoke(category, gearSet);
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
}