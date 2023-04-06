using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    private const float FADE_DUR = .3f;
    
    private PlayerInteractionManager player;
    private CanvasGroup canvasGroup;
    private TMP_Text text;

    private void Awake()
    {
        player = FindObjectOfType<PlayerInteractionManager>();
        canvasGroup = GetComponentInParent<CanvasGroup>();
        text = GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        text.text = $"Press \"E\" to {player.GetInteractionLabel()}";
        if (player.ShouldDisplayInteractToggle())
            Show();
        else
            Hide();
    }
    private void Show()
    {
        canvasGroup.DOFade(1f, FADE_DUR);
        transform.DOScale(Vector3.one, FADE_DUR);
    }

    private void Hide()
    {
        canvasGroup.DOFade(0f, FADE_DUR);
        transform.DOScale(Vector3.zero, FADE_DUR);
    }
}
