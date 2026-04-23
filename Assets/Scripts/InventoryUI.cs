using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Transform gridParent;
    public InventorySlot[] slots;
    public GameObject nextPageButton;
    public GameObject prevPageButton;

    private int _currentPage = 0;
    private int _itemsPerPage;

    void Start()
    {
        _itemsPerPage = slots.Length;
        // Subscribe to changes in the inventory
        InventoryManager.OnInventoryChanged += RefreshUI;
        RefreshUI();
    }

    public void RefreshUI()
    {
        Debug.Log("Hit");
        List<Item> allItems = InventoryManager.Instance.items;
        int startIndex = _currentPage * _itemsPerPage;

        for (int i = 0; i < _itemsPerPage; i++)
        {
            int itemIndex = startIndex + i;

            if (itemIndex < allItems.Count)
                slots[i].Setup(allItems[itemIndex]);
            else
                slots[i].Clear();
        }

        // Toggle pagination buttons
        prevPageButton.SetActive(_currentPage > 0);
        nextPageButton.SetActive(startIndex + _itemsPerPage < allItems.Count);

        if (_currentPage > 0 && _currentPage * _itemsPerPage >= allItems.Count )
        {
            PrevPage();
        }
    }

    public void NextPage() { _currentPage++; RefreshUI(); }
    public void PrevPage() { _currentPage--; RefreshUI(); }
}