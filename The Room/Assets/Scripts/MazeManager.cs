using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [ContextMenu("Complete Maze")]
    public void OnMazeComplete()
    {
        foreach (Transform container in transform)
        {
            container.DOScale(Vector3.zero, 1f).SetEase(Ease.InElastic);
            Destroy(container.gameObject, 1.5f);
        }
    }
}
