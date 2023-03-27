using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private Transform pointsParent;
    [SerializeField] private Transform player;
    [SerializeField] private float pointDistance = 1.5f;
    public UnityEvent onAllPointsCollected;

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
                break;
            }
            else
                point.transform.localPosition += Vector3.up * Mathf.Sin(Time.time);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (Transform point in pointsParent)
            Gizmos.DrawWireSphere(point.position, pointDistance);
    }
}
