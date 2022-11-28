using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public LevelManager LevelManager;
    public Difficulty Difficulty;
    public GameObject PauseMenu;

    private SaveManager SaveManager;
    private PauseManager PauseManager;

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
        LevelManager.CompleteLevel(levelId);
        LevelManager.UnlockNextLevel(levelId);
        LevelManager.Save();
        SceneManager.LoadScene("Home");
    }

    public bool IsMainMenu() => SceneManager.GetActiveScene().name != "MainMenu";

    public void Save(List<Level> levels) => SaveManager.Save(levels);

    public List<Level> Load() => SaveManager.Load();

    public bool HasSaveData() => SaveManager.HasSaveData();

    public void DeleteSaveData() => SaveManager.DeleteSaveData();

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) => ConfigureManagers();

    private void ConfigureManagers()
    {
        SaveManager = FindObjectOfType<SaveManager>();
        LevelManager = FindObjectOfType<LevelManager>();
        PauseManager = FindObjectOfType<PauseManager>();

        if (PauseManager != null)
        {
            PlayerInput playerInput = FindObjectOfType<PlayerInput>();
            Conductor conductor = FindObjectOfType<Conductor>();

            PauseManager.PlayerInput = playerInput;
            PauseManager.Conductor = conductor;
        }
    }
}
