using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Difficulty Difficulty;
    public GameObject PauseMenu;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    public void NewGame()
    {
        LevelManager.Instance.NewGame();
        ChangeScene("Introduction");
    }

    public void ContinueGame()
    {
        LevelManager.Instance.ContinueGame();
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
        LevelManager.Instance.CompleteLevel(levelId);
        LevelManager.Instance.UnlockNextLevel(levelId);
        LevelManager.Instance.Save();
        SceneManager.LoadScene("Home");
    }

    public void TogglePause(InputAction.CallbackContext context)
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            PauseManager.Instance.TogglePause(context);
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "MainMenu" && PauseManager.Instance != null)
        {
            PlayerInput playerInput = FindObjectOfType<PlayerInput>();
            PauseManager.Instance.PlayerInput = playerInput;

            if (scene.name != "Home")
            {
                Conductor conductor = FindObjectOfType<Conductor>();
                PauseManager.Instance.Conductor = conductor;
            }
            else
            {
                PauseManager.Instance.Conductor = null;
            }
        }
    }
}
