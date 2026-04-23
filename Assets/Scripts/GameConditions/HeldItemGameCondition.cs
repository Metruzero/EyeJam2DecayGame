using UnityEngine;

[CreateAssetMenu(fileName = "HeldItemGameCondition", menuName = "GameConditions/HeldItemGameCondition")]
public class HeldItemGameCondition : GameCondition
{
    public ItemType ItemType;

    public override bool Check(InteractionContext context)
    {
        return context.HeldItem == ItemType;
    }
}
