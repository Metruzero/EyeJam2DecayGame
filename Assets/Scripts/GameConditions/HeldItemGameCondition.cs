using UnityEngine;

[CreateAssetMenu(fileName = "HeldItemGameCondition", menuName = "GameConditions/HeldItemGameCondition")]
public class HeldItemGameCondition : GameCondition
{
    public Item Item;

    public override bool Check(InteractionContext context)
    {
        return context.HeldItem == Item;
    }
}
