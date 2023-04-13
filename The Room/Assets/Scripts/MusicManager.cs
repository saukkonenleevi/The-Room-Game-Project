using System;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Config")] 
    [SerializeField] private float crossFadeRange = 2f;
    
    [Header("References")]
    [SerializeField] private AudioSource roomSource;
    [SerializeField] private AudioSource gameSource;
    private Transform player;

    private void Awake()
    {
        player = roomSource.transform.parent;
    }

    private void Update()
    {
        var zDiff = player.transform.position.z - transform.position.z;
        var r = (zDiff / crossFadeRange + 1) * .5f;
        roomSource.volume = Mathf.Lerp(0f, 1f, r);
        gameSource.volume = Mathf.Lerp(1f, 0f, r);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector3(100f, 1f, crossFadeRange));
    }
}
