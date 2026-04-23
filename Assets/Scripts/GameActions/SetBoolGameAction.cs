using UnityEngine;

[CreateAssetMenu(fileName = "SetBoolGameAction", menuName = "GameActions/SetBoolGameAction")]
public class SetBoolGameAction : GameAction
{
    public BoolVariable boolSO;
    public bool setValue = true;

    public override void Execute(InteractionContext context)
    {
        if (boolSO != null)
        {
            boolSO.value = setValue;
        }
    }
}
