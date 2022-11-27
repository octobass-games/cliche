using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool IsPaused;

    public LevelManager LevelManager;
    public Difficulty Difficulty;
    public GameObject PauseMenu;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

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

    public void LoadLevel(string levelName, Difficulty difficulty)
    {
        ChangeScene(levelName);
        Difficulty = difficulty;
    }

    public void SkipLevel()
    {

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
        PauseManager.Instance.TogglePause(context);
    }

}
