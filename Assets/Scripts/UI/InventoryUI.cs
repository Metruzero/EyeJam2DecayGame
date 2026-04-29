using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Transform gridParent;
    public InventorySlot[] slots;
    public GameObject nextPageButton;
    public GameObject prevPageButton;

    private int currentPage = 0;
    private int itemsPerPage;

    void Start()
    {
        itemsPerPage = slots.Length;
        InventoryManager.OnInventoryChanged += RefreshUI;
        RefreshUI();
    }

    public void RefreshUI()
    {
        List<Item> allItems = InventoryManager.Instance.items;
        int startIndex = currentPage * itemsPerPage;

        for (int i = 0; i < itemsPerPage; i++)
        {
            int itemIndex = startIndex + i;

            if (itemIndex < allItems.Count)
                slots[i].Setup(allItems[itemIndex]);
            else
                slots[i].Clear();
        }

        prevPageButton.SetActive(currentPage > 0);
        nextPageButton.SetActive(startIndex + itemsPerPage < allItems.Count);

        if (currentPage > 0 && currentPage * itemsPerPage >= allItems.Count )
        {
            PrevPage();
        }
    }

    public void NextPage() { currentPage++; RefreshUI(); }
    public void PrevPage() { currentPage--; RefreshUI(); }
}