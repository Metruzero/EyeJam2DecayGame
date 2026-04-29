using UnityEngine;

[CreateAssetMenu(fileName = "ClearHeldItemGameAction", menuName = "GameActions/ClearHeldItemGameAction")]
public class ClearHeldItemGameAction : GameAction
{
    public override void Execute(InteractionContext context)
    {
        InventorySelectionManager.Instance.ClearHeldItem();
    }
}
