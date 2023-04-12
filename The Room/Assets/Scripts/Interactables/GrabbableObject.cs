using UnityEngine;

public class GrabbableObject : MonoBehaviour, IInteractableObject
{
    private const float LERP_SPEED = 10f;
    private const float THROW_FORCE = 200f;
    
    [SerializeField, Range(1f, 5f)] private float throwForceMultiplier = 1f;

    private Rigidbody rb;
    private Transform objectGrabPointTransform;
    private Transform cam;

    private void Awake()
    {
        cam = Camera.main.transform;
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
        // We multiply the mass of the object by the throw force multiplier to make it feel the same for all objects.
        rb.AddForce(cam.forward * (THROW_FORCE * rb.mass * throwForceMultiplier));
        rb.useGravity = true;

        objectGrabPointTransform = null;
    }

    bool IInteractableObject.IsToggleable() => true;
    string IInteractableObject.GetInteractionLabel() => "Grab";
    string IInteractableObject.GetUnInteractionLabel() => "Throw";
}
