using UnityEngine;
using System.Collections.Generic;
using System;

public class Interactable : MonoBehaviour, IInteractable
{
    private bool _initialActiveState;
    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    private Sprite _initialSprite;

    public string id = "";

    public static List<Interactable> AllInteractables = new List<Interactable>();

    [Header("Behavior Logic")]
    public List<ConditionActionGroup> interactionGroups;

    private void Awake()
    {
        _initialActiveState = gameObject.activeSelf;
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
        SpriteRenderer spriteRender = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRender != null )
        {
            _initialSprite = spriteRender.sprite;
        }
        AllInteractables.Add( this );
        if (id != "")
        {
            ObjectRegistry.Instance.Register(id, this.gameObject);
        }
        
    }

    public void ResetToStartingState()
    {
        gameObject.SetActive(_initialActiveState);
        transform.position = _initialPosition;
        transform.rotation = _initialRotation;
        if (_initialSprite != null)
        {
            SpriteRenderer spriteRender = gameObject.GetComponent<SpriteRenderer>();
            if (spriteRender != null)
            {
                spriteRender.sprite = _initialSprite;
            }

        }
    }

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
                return;
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