using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using static UnityEditor.Progress;

public enum ItemType
{
    None,
    Book
}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<ItemType> items = new List<ItemType>();

    public static event Action OnInventoryChanged;

    public void AddItem(ItemType item)
    {
        items.Add(item);
        OnInventoryChanged?.Invoke();
    }

    public void RemoveItem(ItemType item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            OnInventoryChanged?.Invoke();
        }
    }

    public bool HasItem(ItemType item) => items.Contains(item);

    public void ResetInventory()
    {
        items.Clear();
        OnInventoryChanged?.Invoke();
    }
}
