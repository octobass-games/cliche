using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Saver Saver;

    public List<SerializableLevel> Levels { get; private set; }

    private readonly List<SerializableLevel> InitialLevelData = new()
    {
        new SerializableLevel("Siren", LevelState.UNLOCKED, 0, 100, 200),
        new SerializableLevel("Forest", LevelState.LOCKED, 0, 100, 200),
        new SerializableLevel("", LevelState.LOCKED, 0, 100, 200)
    };

    void Awake()
    {
        // load levels by default or initialise to empty
        Levels = Saver.Load();

        if (Levels == null || Levels.Count == 0)
        {
            NewGame();
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

    public void SetHighScore(string levelId, int highScore)
    {
        var level = Levels.Find(level => level.Id == levelId);

        if (level != null && level.HighScore < highScore)
        {
            level.HighScore = highScore;
            level.Medal = GetMedal(level, highScore);
        }
    }

    public void CompleteLevel()
    {
        var currentLevel = Levels.Find(level => level.State == LevelState.UNLOCKED);

        if (currentLevel != null)
        {
            currentLevel.State = LevelState.COMPLETED;
        }
    }

    public void UnlockNextLevel()
    {
        var nextLevel = Levels.Find(level => level.State == LevelState.LOCKED);

        if (nextLevel != null)
        {
            nextLevel.State = LevelState.UNLOCKED;
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
}
