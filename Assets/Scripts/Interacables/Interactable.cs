using UnityEngine;
using System.Collections.Generic;
using System;

public class Interactable : MonoBehaviour, IInteractable
{
    private bool initialActiveState;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Sprite initialSprite;
    private bool initialSpriteRenderState;
    private bool initialColliderState;

    private SpriteRenderer spriteRender;
    private Collider2D colliderObj;

    public string id = "";

    public static List<Interactable> AllInteractables = new List<Interactable>();

    public List<ConditionActionGroup> interactionGroups;

    private void Awake()
    {
        initialActiveState = gameObject.activeSelf;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        colliderObj = gameObject.GetComponent<Collider2D>();
        if (spriteRender != null )
        {
            initialSprite = spriteRender.sprite;
            initialSpriteRenderState = spriteRender.enabled;
        }
        AllInteractables.Add( this );
        if (id != "")
        {
            ObjectRegistry.Instance.Register(id, this.gameObject);
        }
        if (colliderObj != null)
        {
            initialColliderState = colliderObj.enabled;
        }

        
        
    }

    public void ResetToStartingState()
    {
        gameObject.SetActive(initialActiveState);
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        if (spriteRender != null)
        {
            spriteRender.sprite = initialSprite;
            spriteRender.enabled = initialSpriteRenderState;
        }
        if (colliderObj != null)
        {
            colliderObj.enabled = initialColliderState;
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