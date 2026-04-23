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

    public List<Item> items = new List<Item>();

    public static event Action OnInventoryChanged;

    public Item heldItem = null;

    private void Awake() => Instance = this;

    public void AddItem(Item item)
    {
        Debug.Log("Hit");
        items.Add(item);
        OnInventoryChanged?.Invoke();
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            OnInventoryChanged?.Invoke();
        }
    }

    public bool HasItem(Item item) => items.Contains(item);

    public void ResetInventory()
    {
        items.Clear();
        OnInventoryChanged?.Invoke();
    }

    public void HoldItem(Item item)
    {
        heldItem = item;
    }

    public void ReleaseItem()
    {
        heldItem = null;
    }
}
