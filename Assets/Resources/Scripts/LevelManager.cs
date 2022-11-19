using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Saver Saver;

    private List<SerializableLevel> Levels;

    private readonly List<SerializableLevel> InitialLevelData = new()
    {
        new SerializableLevel("", 0, false),
        new SerializableLevel("", 0, false),
        new SerializableLevel("", 0, false)
    };

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
        }
    }

    public void UnlockNextLevel()
    {
        var nextLevel = Levels.Find(level => !level.IsUnlocked);

        if (nextLevel != null)
        {
            nextLevel.IsUnlocked = true;
        }
    }

    public void Save()
    {
        Saver.Save(Levels);
    }
}
