using UnityEngine;

[CreateAssetMenu(fileName = "HideTargetGameAction", menuName = "GameActions/HideTargetGameAction")]
public class HideTargetGameAction : GameAction
{
    public override void Execute(InteractionContext context)
    {
        context.Target.GetComponent<SpriteRenderer>().enabled = false;
        context.Target.GetComponent<Collider2D>().enabled = false;
    }
}
