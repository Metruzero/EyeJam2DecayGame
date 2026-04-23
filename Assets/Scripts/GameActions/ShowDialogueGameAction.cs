using UnityEngine;
[CreateAssetMenu(fileName = "ShowDialogueGameAction", menuName = "GameActions/ShowDialogueGameAction")]
public class ShowDialogueGameAction : GameAction
{
    public string DisplayText;

    public override void Execute(InteractionContext context)
    {
        DialogueManager.Instance.ShowDialogue(DisplayText);
    }
}
