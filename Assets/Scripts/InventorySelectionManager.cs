using UnityEngine;

public class InventorySelectionManager : MonoBehaviour
{
    public static InventorySelectionManager Instance;
    public Item heldItem;

    // Optional: Change the cursor to the item icon
    public UnityEngine.UI.Image cursorFollower;

    private void Awake() => Instance = this;

    public void SetHeldItem(Item item)
    {
        heldItem = item;
        Debug.Log("Now holding: " + item.itemName);

        // Update visual feedback (e.g., cursor or highlight)
        if (cursorFollower != null)
        {
            cursorFollower.sprite = item.icon;
            cursorFollower.gameObject.SetActive(true);
        }
    }

    public void ClearHeldItem()
    {
        heldItem = null;
        if (cursorFollower != null) cursorFollower.gameObject.SetActive(false);
    }
}
