using UnityEngine;

public class GrabbableObject : MonoBehaviour, IInteractableObject
{
    private const float LERP_SPEED = 10f;
    
    private Rigidbody rb;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularDrag = 5f;
    }
    
    private void FixedUpdate()
    {
        if (!objectGrabPointTransform) return;
        
        var newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * LERP_SPEED);
        rb.MovePosition(newPosition);
    }
    
    void IInteractableObject.Interact(Transform interactPos)
    {
        objectGrabPointTransform = interactPos;
        rb.useGravity = false;
    }
    void IInteractableObject.UnInteract()
    {
        objectGrabPointTransform = null;
        rb.useGravity = true;
    }

    bool IInteractableObject.IsToggleable() => true;
    string IInteractableObject.GetInteractionLabel() => "Grab";
    string IInteractableObject.GetUnInteractionLabel() => "Drop";
}
