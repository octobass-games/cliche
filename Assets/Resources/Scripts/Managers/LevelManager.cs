using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public SaveManager Saver;

    public static LevelManager Instance;

    public List<SerializableLevel> Levels { get; private set; }

    private readonly List<SerializableLevel> InitialLevelData = new()
    {

        new SerializableLevel("Siren", LevelState.UNLOCKED, 0, 0, 0, 100, 200),
        new SerializableLevel("Forest", LevelState.LOCKED, 0, 0, 0, 100, 200),
        new SerializableLevel("Spooky", LevelState.LOCKED, 0, 0, 0, 100, 200),
        new SerializableLevel("City", LevelState.LOCKED, 0, 0, 0, 100, 200),
        new SerializableLevel("Chill", LevelState.LOCKED, 0, 0, 0, 100, 200),
        new SerializableLevel("Scifi", LevelState.LOCKED, 0, 0, 0, 100, 200),
        new SerializableLevel("Battle", LevelState.LOCKED, 0, 0, 0, 100, 200),
        new SerializableLevel("Party", LevelState.LOCKED, 0, 0, 0, 100, 200)
    };

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            
            // load levels by default or initialise to empty
            Levels = Saver.Load();

            if (Levels == null || Levels.Count == 0)
            {
                NewGame();
            }
        }
    }

    public void NewGame()
    {
        Levels = InitialLevelData;

        Saver.DeleteSaveData();
        Saver.Save(Levels);
    }

    public void ContinueGame()
    {
        Levels = Saver.Load();
    }

    public void SetHighScore(string levelId, int highScore, Difficulty difficulty)
    {
        var level = Levels.Find(level => level.Id == levelId);

        if (level != null)
        {
            if (difficulty == Difficulty.EASY && level.EasyHighScore < highScore)
            {
                level.EasyHighScore = highScore;
                level.EasyMedal = GetMedal(level, highScore);
            }
            else if (difficulty == Difficulty.NORMAL && level.NormalHighScore < highScore)
            {
                level.NormalHighScore = highScore;
                level.NormalMedal = GetMedal(level, highScore);
            }
            else if (level.HardHighScore < highScore)
            {
                level.HardHighScore = highScore;
                level.NormalMedal = GetMedal(level, highScore);
            }
        }
    }

    public void CompleteLevel(string levelId)
    {
        var currentLevel = Levels.Find(level => level.Id == levelId);

        if (currentLevel != null)
        {
            currentLevel.State = LevelState.COMPLETED;
        }
    }

    public void UnlockNextLevel(string currentLevelId)
    {
        var currentLevelIndex = Levels.FindIndex(level => level.Id == currentLevelId);
        var nextLevelIndex = currentLevelIndex + 1;

        if (nextLevelIndex < Levels.Count)
        {
            var nextLevel = Levels[nextLevelIndex];

            if (nextLevel.State != LevelState.COMPLETED)
            {
                nextLevel.State = LevelState.UNLOCKED;
            }
        }
    }

    public void Save()
    {
        Saver.Save(Levels);
    }

    private Medal GetMedal(SerializableLevel level, int score)
    {
        if (level.GoldScore <= score)
        {
            return Medal.GOLD;
        }
        else if (level.SilverScore <= score)
        {
            return Medal.SILVER;
        }
        else
        {
            return Medal.BRONZE;
        }
    }

    public SerializableLevel FindLevel(string id) => Levels.Find(l => l.Id == id);
}
