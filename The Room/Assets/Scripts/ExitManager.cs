using UnityEngine;

public class ExitManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            Debug.Log("Requested to Quit the application.");
#endif

            Application.Quit();
        }
    }
}
