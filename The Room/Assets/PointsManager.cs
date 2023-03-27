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
                Destroy(point.gameObject, .2f);
                Debug.Log("Collected one point");
                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (Transform point in pointsParent)
            Gizmos.DrawWireSphere(point.position, pointDistance);
    }
}
