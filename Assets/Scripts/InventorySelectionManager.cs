using UnityEngine;

public class InventorySelectionManager : MonoBehaviour
{
    public static InventorySelectionManager Instance;
    public Item heldItem;

    public UnityEngine.UI.Image cursorFollower;

    private void Awake() => Instance = this;

    private void Start()
    {
        LoopResetManager.OnLoopReset += ClearHeldItem;
    }

    public void SetHeldItem(Item item)
    {
        heldItem = item;

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
