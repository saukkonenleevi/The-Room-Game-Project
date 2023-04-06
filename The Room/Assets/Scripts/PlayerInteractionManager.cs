using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] private float pickUpDistance = 4f;
    
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private IInteractableObject currentInteraction;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // If the player is not interacting with an object
            if (currentInteraction == null)
            {
                var target = GetAimedInteractable();
                if (target == null) return;
                
                target.Interact(objectGrabPointTransform);
                if (target.IsToggleable())
                    currentInteraction = target;
            }
            // If there is an interaction that can be uninteracted, do it
            else
            {
                currentInteraction.UnInteract();
                currentInteraction = null;
            }
        }
    }

    private IInteractableObject GetAimedInteractable()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out var raycastHit, pickUpDistance, pickUpLayerMask))
            return raycastHit.transform.GetComponent<IInteractableObject>();

        return null;
    }

    public bool ShouldDisplayInteractToggle() => currentInteraction != null || GetAimedInteractable() != null;

    public string GetInteractionLabel()
    {
        if (currentInteraction != null) return currentInteraction.GetUnInteractionLabel();
        
        var target = GetAimedInteractable();
        if (target != null)
            return target.GetInteractionLabel();

        return "";
    }
}
