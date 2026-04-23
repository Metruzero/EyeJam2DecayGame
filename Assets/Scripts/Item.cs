using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("Basic Info")]
    public string itemName;
    [TextArea(3, 10)]
    public string description;

    [Header("Visuals")]
    public Sprite icon;
    public Sprite cursorSprite;

    [Header("Game Logic")]
    public string itemID;
    public bool isConsumable;
}