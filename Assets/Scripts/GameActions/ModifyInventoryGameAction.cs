using UnityEngine;

[CreateAssetMenu(fileName = "ModifyInventoryGameAction", menuName = "GameActions/ModifyInventoryGameAction")]
public class ModifyInventoryGameAction : GameAction
{
    public Item item;
    public int modifyValue;
    public override void Execute(InteractionContext context)
    {
        InventoryManager inventoryManager = InventoryManager.Instance;
        if (modifyValue == 1)
        {
            inventoryManager.AddItem(item);
        }
        else
        {
            inventoryManager.RemoveItem(item);
        }

    }
}
