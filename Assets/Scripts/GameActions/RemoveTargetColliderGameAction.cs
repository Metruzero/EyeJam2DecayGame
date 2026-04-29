using UnityEngine;

[CreateAssetMenu(fileName = "RemoveTargetColliderGameAction", menuName = "GameActions/RemoveTargetColliderGameAction")]
public class RemoveTargetColliderGameAction : GameAction
{
    public override void Execute(InteractionContext context)
    {
        context.Target.GetComponent<Collider2D>().enabled = false;
    }
}
