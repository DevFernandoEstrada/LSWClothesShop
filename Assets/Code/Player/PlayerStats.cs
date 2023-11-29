using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stats currentStats;

    public static event Action OnStatsUpdated; 

    private void OnEnable()
    {
        PlayerInventory.OnGearSetChanged += UpdateStats;
    }

    private void OnDisable()
    {
        PlayerInventory.OnGearSetChanged -= UpdateStats;
    }

    private void UpdateStats(ItemCategory category, GearSet gearSet)
    {
        currentStats = GetComponent<PlayerInventory>().GetEquippedStats();
        OnStatsUpdated?.Invoke();
    }
}