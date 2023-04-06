using UnityEngine;

public interface IInteractableObject
{
    /// <summary>
    /// Determines what to do the player interacts with the object
    /// </summary>
    /// <param name="interactPos">The position for stuff like grabbing</param>
    public void Interact(Transform interactPos);
    /// <summary>
    /// Determines what to do if the player stops the interaction with the object
    /// </summary>
    public void UnInteract() {}
    

    /// <summary>
    /// This determines if the UnInteract method should get used
    /// ex: Grabbing should have this true cuz it can also be dropped
    /// but pushing a button should not cuz you can't "unpush"
    /// </summary>
    public bool IsToggleable();
    
    /// <summary>
    /// The label the UI will display to interact with the object
    /// </summary>
    public string GetInteractionLabel() => "Interact";
    /// <summary>
    /// The label the UI will display to stop interacting with the object
    /// </summary>
    public string GetUnInteractionLabel() => "Stop Interacting";
}
