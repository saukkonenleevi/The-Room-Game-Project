using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private FirstPersonController player;
    private NavMeshAgent agent;
    
    private void Awake()
    {
        player = FindObjectOfType<FirstPersonController>();
        agent = GetComponent<NavMeshAgent>();
    }
    
    private void Update()
    {
        agent.destination = player.transform.position;
    }
}
