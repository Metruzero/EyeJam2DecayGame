using UnityEngine;

[CreateAssetMenu(fileName = "ChangeSpriteGameAction", menuName = "GameActions/ChangeSpriteGameAction")]
public class ChangeSpriteGameAction : GameAction
{
    public Sprite newSprite;

    public override void Execute(InteractionContext context)
    {
        SpriteRenderer spriteComp = context.Target.GetComponent<SpriteRenderer>();
        spriteComp.sprite = newSprite;
    }
}
