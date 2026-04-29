using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    public LayerMask filteredLayer;
    public Camera sceneCamera;

    InputAction clickAction;


    private void Start()
    {
        clickAction = InputSystem.actions.FindAction("Click");
    }

    private void Update()
    {
        if (clickAction.WasPressedThisFrame())
        {
            Interactable interactable = GetInteractable();
            if (interactable != null)
            {
                InteractionContext context = CreateContext(interactable.gameObject);
                if (context.HeldItem != null) Debug.Log(context.HeldItem.itemName);
                if (interactable.CanInteract(context))
                {
                    interactable.Interact(context);
                }
            }
            else
            {
                InventoryManager.Instance.ReleaseItem();
            }
        }
    }

    private Interactable GetInteractable()
    {
        Vector2 rawMousePos = Mouse.current.position.ReadValue();

        Ray ray = sceneCamera.ScreenPointToRay(rawMousePos);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 100f, filteredLayer);
        if (hit.collider != null)
        {
            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
            return interactable;
        }

        return null;
    }

    private InteractionContext CreateContext(GameObject target)
    {
        return new InteractionContext
        {
            Interactor = this.gameObject,
            Target = target,
            HeldItem = InventorySelectionManager.Instance.heldItem,

        };
    }
}
