using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public bool isActive = false;
    private CanvasGroup canvasGroup;
    
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
    }

    private void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Activate()
    {
        isActive = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1f, .7f);
    }
}
