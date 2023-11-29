using UnityEngine;

public enum ItemCategory
{
    Base,
    Head,
    Body,
}

public enum ItemRarity
{
    Common,
    Rare,
    Legendary
}

[CreateAssetMenu(fileName = "Gear", menuName = "Little Sim World/Gear", order = 1)]
public class GearSet : ScriptableObject
{
    public int id;
    public string gearName;
    public string description;
    public int value;
    public ItemCategory category;
    public ItemRarity rarity;
    public Sprite icon;
    public Stats stats;
    public Sprite[] spriteSheet;
}
