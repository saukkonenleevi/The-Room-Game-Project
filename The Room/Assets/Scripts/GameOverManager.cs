using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public bool isActive = false;
    
    private CanvasGroup canvasGroup;
    private MusicManager musicManager;
    
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        musicManager = FindObjectOfType<MusicManager>();

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
        
        musicManager.SetCreditsVolume(1f);
    }
}
