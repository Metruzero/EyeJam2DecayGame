using UnityEngine;
using UnityEngine.LightTransport;

public interface IInteractable
{
    bool CanInteract(InteractionContext context);
    void Interact(InteractionContext context);
}
