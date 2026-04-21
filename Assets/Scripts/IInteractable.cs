using UnityEngine;
using UnityEngine.LightTransport;

public interface IInteractable
{
    string GetInteractionPrompt();
    bool CanInteract(InteractionContext context);
    void Interact(InteractionContext context);
}
