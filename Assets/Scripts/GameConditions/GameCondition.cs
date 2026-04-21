using UnityEngine;

[CreateAssetMenu(fileName = "GameCondition", menuName = "Scriptable Objects/GameCondition")]
public abstract class GameCondition : ScriptableObject
{
    public abstract bool Check(InteractionContext context);
}
