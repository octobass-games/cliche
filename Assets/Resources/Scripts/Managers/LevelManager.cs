using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string LevelId;

    public List<Level> Levels { get; private set; }

    private readonly List<Level> InitialLevelData = new()
    {
        new Level("Siren", LevelState.UNLOCKED, 0, 0, 0, 100, 200),
        new Level("Forest", LevelState.LOCKED, 0, 0, 0, 100, 200),
        new Level("Spooky", LevelState.LOCKED, 0, 0, 0, 100, 200),
        new Level("City", LevelState.LOCKED, 0, 0, 0, 100, 200),
        new Level("Chill", LevelState.LOCKED, 0, 0, 0, 100, 200),
        new Level("Scifi", LevelState.LOCKED, 0, 0, 0, 100, 200),
        new Level("Battle", LevelState.LOCKED, 0, 0, 0, 100, 200),
        new Level("Party", LevelState.LOCKED, 0, 0, 0, 100, 200)
    };

    void Start()
    {
        LevelId = SceneManager.GetActiveScene().name;
        // load levels by default or initialise to empty
        Levels = GameManager.Instance.Load();

        if (Levels == null || Levels.Count == 0)
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        Levels = InitialLevelData;

        GameManager.Instance.DeleteSaveData();
        GameManager.Instance.Save(Levels);
    }

    public void ContinueGame()
    {
        Levels = GameManager.Instance.Load();
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
                level.HardMedal = GetMedal(level, highScore);
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
        GameManager.Instance.Save(Levels);
    }

    private Medal GetMedal(Level level, int score)
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

    public Level FindLevel(string id) => Levels.Find(l => l.Id == id);

}
