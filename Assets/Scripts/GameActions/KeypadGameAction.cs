using UnityEngine;

[CreateAssetMenu(fileName = "KeypadGameAction", menuName = "GameActions/KeypadGameAction")]
public class KeypadGameAction : GameAction
{
    public string registryID = "";
    public string addedValue = "";
    public bool isSubmit = false;
    public bool isCancel = false;

    public override void Execute(InteractionContext context)
    {
        KeypadController keypad = context.Target.GetComponentInParent<KeypadController>(); ;

        if (isSubmit)
        {
            keypad.Submit();
            return;
        }

        if (isCancel)
        {
            keypad.Clear();
            return;
        }

        keypad.AddNumber(addedValue);
        
    }
}
