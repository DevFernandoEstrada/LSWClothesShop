using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stats currentStats;

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
    }
}