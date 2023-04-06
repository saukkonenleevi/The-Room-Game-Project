using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    private const float FADE_DUR = .3f;
    
    private PlayerInteractionManager player;
    private CanvasGroup canvasGroup;
    private TMP_Text text;

    private bool isHidden = true;

    private void Awake()
    {
        player = FindObjectOfType<PlayerInteractionManager>();
        text = GetComponentInChildren<TMP_Text>();
        
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
    }

    private void Update()
    {
        var interactionLabel = player.GetInteractionLabel();
        if (!string.IsNullOrWhiteSpace(interactionLabel))
            text.text = $"Press \"E\" to {interactionLabel}";
        
        var newIsHidden = player.ShouldDisplayInteractToggle();

        // We do these checks so we call the Show only when the UI is actually hidden and vice versa.
        if (!isHidden && newIsHidden)
            Show();
        else if (isHidden && !newIsHidden)
            Hide();
        
        isHidden = newIsHidden;
    }
    private void Show()
    {
        canvasGroup.DOFade(1f, FADE_DUR);
        transform.DOPunchPosition(Vector3.down, FADE_DUR);
    }

    private void Hide()
    {
        canvasGroup.DOFade(0f, FADE_DUR);
        transform.DOPunchPosition(Vector3.up, FADE_DUR);
    }
}
