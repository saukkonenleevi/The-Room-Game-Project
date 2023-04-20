using System;
using DG.Tweening;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Config")] 
    [SerializeField] private float crossFadeRange = 2f;
    
    [Header("References")]
    [SerializeField] private AudioSource roomSource;
    [SerializeField] private AudioSource gameSource;
    [SerializeField] private AudioSource creditsSource;
    
    private Transform player;
    private float creditsMusicAmount = 0f;
    
    private void Awake()
    {
        player = roomSource.transform.parent;
        creditsMusicAmount = 0f;
    }

    private void Update()
    {
        var zDiff = player.transform.position.z - transform.position.z;
        var r = (zDiff / crossFadeRange + 1) * .5f;
        roomSource.volume = Mathf.Lerp(0f, 1f, r) * (1f - creditsMusicAmount);
        gameSource.volume = Mathf.Lerp(1f, 0f, r) * (1f - creditsMusicAmount);

        creditsSource.volume = creditsMusicAmount;
    }

    public void SetCreditsVolume(float desiredVolume)
    {
        DOTween.To(
            () => creditsMusicAmount,
            val => creditsMusicAmount = val,
            desiredVolume,
            .5f
        );
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector3(100f, 1f, crossFadeRange));
    }
}
