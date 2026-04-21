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
                Debug.Log("We hit!");
                InteractionContext context = CreateContext(interactable.gameObject);

                if (interactable.CanInteract(context))
                {
                    interactable.Interact(context);
                }
            }
        }
    }

    private Interactable GetInteractable()
    {
        Vector2 rawMousePos = Mouse.current.position.ReadValue();
        
        Debug.Log("MousePos: " + rawMousePos);

        Vector3 worldPos = sceneCamera.ScreenToWorldPoint(rawMousePos);


        Ray ray = sceneCamera.ScreenPointToRay(rawMousePos);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 100f, filteredLayer);
        if (hit.collider != null)
        {
            Debug.Log("Real hit?");
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
            HeldItem = ItemType.None

        };
    }
}
