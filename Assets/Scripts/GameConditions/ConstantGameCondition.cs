using UnityEngine;

[CreateAssetMenu(fileName = "ConstantGameCondition", menuName = "GameConditions/ConstantGameCondition")]
public class ConstantGameCondition : GameCondition
{
    public bool constantBool;

    public override bool Check(InteractionContext context)
    {
        return constantBool;
    }
}
