using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string LevelId;

    public List<Level> Levels { get; private set; }
    public float MaxScore;

    private readonly List<Level> InitialLevelData = new()
    {
        new Level("Siren", LevelState.UNLOCKED),
        new Level("Forest", LevelState.LOCKED),
        new Level("Spooky", LevelState.LOCKED),
        new Level("City", LevelState.LOCKED),
        new Level("Chill", LevelState.LOCKED),
        new Level("Scifi", LevelState.LOCKED),
        new Level("Battle", LevelState.LOCKED),
        new Level("Party", LevelState.LOCKED)
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

    public Medal SetHighScore(string levelId, int highScore, Difficulty difficulty)
    {
        var level = Levels.Find(level => level.Id == levelId);

        if (level != null)
        {
            if (difficulty == Difficulty.EASY && level.EasyHighScore < highScore)
            {
                level.EasyHighScore = highScore;
                level.EasyMedal = GetMedal(highScore);
                return level.EasyMedal;
            }
            else if (difficulty == Difficulty.NORMAL && level.NormalHighScore < highScore)
            {
                level.NormalHighScore = highScore;
                level.NormalMedal = GetMedal(highScore);
                return level.NormalMedal;
            }
            else if (level.HardHighScore < highScore)
            {
                level.HardHighScore = highScore;
                level.HardMedal = GetMedal(highScore);
                return level.HardMedal;
            }
        }
        return Medal.NONE;
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

    private Medal GetMedal(int score)
    {
        int platinumScore = Mathf.FloorToInt((MaxScore * 90) / 100);
        int goldScore = Mathf.FloorToInt((MaxScore * 70) / 100);
        int silverScore = Mathf.FloorToInt((MaxScore * 55) / 100);

        if (platinumScore <= score)
        {
            return Medal.PLATINUM;
        }
        else if (goldScore <= score)
        {
            return Medal.GOLD;
        }
        else if (silverScore <= score)
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
