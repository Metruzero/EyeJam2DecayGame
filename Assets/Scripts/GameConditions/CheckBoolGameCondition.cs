using UnityEngine;

[CreateAssetMenu(fileName = "CheckBoolGameCondition", menuName = "GameConditions/CheckBoolGameCondition")]
public class CheckBoolGameCondition : GameCondition
{
    public BoolVariable boolSO;
    public bool requiredState = true;

    public override bool Check(InteractionContext context)
    {
        if (boolSO == null) return false;
        return boolSO.value == requiredState;
    }
}
