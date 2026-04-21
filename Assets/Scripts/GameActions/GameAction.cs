using UnityEngine;

[CreateAssetMenu(fileName = "GameAction", menuName = "Scriptable Objects/GameAction")]
public abstract class GameAction : ScriptableObject
{
    public abstract void Execute(InteractionContext context);
}
