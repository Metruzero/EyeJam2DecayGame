using UnityEngine;

[CreateAssetMenu(fileName = "ChangeGameView", menuName = "GameActions/ChangeGameView")]
public class ChangeGameView : GameAction
{
    public string viewID;

    public override void Execute(InteractionContext context)
    {
        RoomManager roomManager = RoomManager.Instance;
        Debug.Log(roomManager);

        roomManager.SetView(viewID);
    }
}
