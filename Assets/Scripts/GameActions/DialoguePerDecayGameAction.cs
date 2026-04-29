using UnityEngine;

[CreateAssetMenu(fileName = "DialoguePerDecayGameAction", menuName = "GameActions/DialoguePerDecayGameAction")]
public class DialoguePerDecayGameAction : GameAction
{
    public string healthyDialogue, weakDialogue, monsterDialogue;

    public override void Execute(InteractionContext context)
    {
        int phase  = TimeManager.Instance.GetCurrentPhase();

        string text = "";

        if (phase == 0)
        {
            text = healthyDialogue;
        }
        else if (phase == 1)
        {
            text = weakDialogue;
        }
        else if (phase == 2)
        {
            text = monsterDialogue;
        }

        if (text != "")
        {
            DialogueManager.Instance.ShowDialogue(text);
        }
    }
}
