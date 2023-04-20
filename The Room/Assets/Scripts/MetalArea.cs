using System;
using UnityEngine;

public class MetalArea : MonoBehaviour
{
    private FootStepManager player;
    
    private void Awake()
    {
        player = FindObjectOfType<FootStepManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            player.SetClipToUse(1);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            player.SetClipToUse(0);
    }
}
