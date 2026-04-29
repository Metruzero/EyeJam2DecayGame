using UnityEngine;
[CreateAssetMenu(fileName = "ShowDialogueGameAction", menuName = "GameActions/ShowDialogueGameAction")]
public class ShowDialogueGameAction : GameAction
{
    public string DisplayText;

    public override void Execute(InteractionContext context)
    {
        Debug.Log("ShowDialogue");
        DialogueManager.Instance.ShowDialogue(DisplayText);
    }
}
