using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class PointsManager : MonoBehaviour
{
    public UnityEvent onAllPointsCollected;
    [Header("References")]
    [SerializeField] private Transform pointsParent;
    [SerializeField] private Transform player;
    [SerializeField] private float pointDistance = 1.5f;
    [Header("Bobbing")] 
    [SerializeField, Range(.5f, 20f)] private float bobbingFrequency = 5f;
    [SerializeField, Range(0f, 1f)] private float bobbingAmplitude = .2f;
    
    private Dictionary<Transform, Vector3> pointPositions = new();
    private GameOverManager gameOverManager;

    private void Awake()
    {
        gameOverManager = FindObjectOfType<GameOverManager>();
    }

    private void Start()
    {
        foreach (Transform point in pointsParent)
            pointPositions.Add(point, point.position);
    }

    private void Update()
    {
        if (pointsParent.childCount == 0)
        {
            onAllPointsCollected.Invoke();
            Destroy(gameObject);
            return;
        }
        
        foreach (Transform point in pointsParent)
        {
            if (Vector3.Distance(point.position, player.position) <= pointDistance)
            {
                point.parent = null;

                point.transform.DORotate(Vector3.up * 3000f, .6f, RotateMode.WorldAxisAdd);
                point.transform.DOScale(0f, .5f);
                point.transform.DOMoveY(point.transform.position.y + .5f, .5f);

                Destroy(point.gameObject, .5f);

                if (pointsParent.childCount == 0)
                    gameOverManager.Activate();
                
                break;
            }
            else if (point.name[0] != 'G')
                point.transform.position = pointPositions[point] + Vector3.up * (Mathf.Sin(Time.time * bobbingFrequency) * bobbingAmplitude);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (Transform point in pointsParent)
            Gizmos.DrawWireSphere(point.position, pointDistance);
    }
}
