using UnityEngine;

[CreateAssetMenu(fileName = "HideAllRoomsGameAction", menuName = "GameActions/HideAllRoomsGameAction")]
public class HideAllRoomsGameAction : GameAction
{
    public override void Execute(InteractionContext context)
    {
        RoomManager.Instance.HideAllRooms();
    }
}
