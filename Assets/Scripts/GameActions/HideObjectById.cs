using UnityEngine;

[CreateAssetMenu(fileName = "SetObjectStateById", menuName = "GameActions/SetObjectStateById")]
public class SetObjectStateById : GameAction
{
    public string id;
    public bool setState;

    public override void Execute(InteractionContext context)
    {
        ObjectRegistry.Instance.SetObjectState(id, setState);
    }
}
