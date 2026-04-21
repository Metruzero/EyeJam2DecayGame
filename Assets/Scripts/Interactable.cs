using UnityEngine;
using System.Collections.Generic;

public class Interactable : MonoBehaviour, IInteractable
{
    [Header("UI Settings")]
    public string interactionPrompt = "Examine";

    [Header("Behavior Logic")]
    [Tooltip("The system will execute the first group whose conditions are met.")]
    public List<ConditionActionGroup> interactionGroups;

    public string GetInteractionPrompt() => interactionPrompt;

    public bool CanInteract(InteractionContext context)
    {
        foreach (var group in interactionGroups)
        {
            if (group.AllConditionsMet(context)) return true;
        }
        return false;
    }

    public void Interact(InteractionContext context)
    {
        foreach (var group in interactionGroups)
        {
            if (group.AllConditionsMet(context))
            {
                group.ExecuteActions(context);
                return; // Stop after the first valid group is found
            }
        }
        Debug.Log($"{name}: No valid interaction for current state.");
    }
}

[System.Serializable]
public struct ConditionActionGroup
{
    public List<GameCondition> conditions;
    public List<GameAction> actions; 

    public bool AllConditionsMet(InteractionContext context)
    {
        foreach (var condition in conditions)
        {
            if (!condition.Check(context)) return false;
        }
        return true;
    }

    public void ExecuteActions(InteractionContext context)
    {
        foreach (var action in actions)
        {
            action.Execute(context);
        }
    }
}