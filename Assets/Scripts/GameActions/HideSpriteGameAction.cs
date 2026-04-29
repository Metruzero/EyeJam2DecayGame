using UnityEngine;

[CreateAssetMenu(fileName = "HideSpriteGameAction", menuName = "GameActions/HideSpriteGameAction")]
public class HideSpriteGameAction : GameAction
{
    public override void Execute(InteractionContext context)
    {
        context.Target.GetComponent<SpriteRenderer>().enabled = false;
    }
}
