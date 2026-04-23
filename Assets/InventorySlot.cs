using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image iconImage;
    public Button button;
    private Item _currentItem;

    public void Setup(Item item)
    {
        _currentItem = item;
        iconImage.sprite = item.icon;
        iconImage.enabled = true;
        button.interactable = true;
    }

    public void Clear()
    {
        _currentItem = null;
        iconImage.enabled = false;
        button.interactable = false;
    }

    public void OnSlotClicked()
    {
        if (_currentItem != null)
        {
            // Tell the controller that this is now the "Held" item
            InventorySelectionManager.Instance.SetHeldItem(_currentItem);
        }
    }
}
