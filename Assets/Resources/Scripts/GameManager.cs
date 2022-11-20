using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool IsPaused;

    public LevelManager LevelManager;

    public void NewGame()
    {
        LevelManager.NewGame();
        ChangeScene("Introduction");
    }

    public void ContinueGame()
    {
        LevelManager.ContinueGame();
        ChangeScene("Home");
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CompleteLevel(string levelId)
    {
        Debug.Log("Marking level complete: " + levelId);
        LevelManager.CompleteLevel(levelId);
        LevelManager.UnlockNextLevel(levelId);
        LevelManager.Save();
        SceneManager.LoadScene("Home");
    }

    public void TogglePause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (IsPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        FindObjectOfType<Conductor>().Pause();
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("UI");
        IsPaused = true;
    }

    private void Unpause()
    {
        Time.timeScale = 1f;
        FindObjectOfType<Conductor>().Resume();
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("Player controls");
        IsPaused = false;
    }
}
