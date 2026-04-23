using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<Item> allItems;

    public Item GetItemByID(string id)
    {
        return allItems.Find(i => i.itemID == id);
    }
}