using UnityEngine;

public class QuitButton : MonoBehaviour
{
    void Awake()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
