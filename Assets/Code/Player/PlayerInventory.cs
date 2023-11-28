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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeGearSet(gearSets[0].category, gearSets[0]);
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeGearSet(gearSets[1].category, gearSets[1]);
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            ChangeGearSet(gearSets[2].category, gearSets[2]);
        }
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ChangeGearSet(gearSets[3].category, gearSets[3]);
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