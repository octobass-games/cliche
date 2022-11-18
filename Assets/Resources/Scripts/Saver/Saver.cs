using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Saver : MonoBehaviour
{
    private string SaveFilePath;

    private List<SerializableLevel> InitialSaveData = new()
    {
        new SerializableLevel("", 0),
        new SerializableLevel("", 0),
        new SerializableLevel("", 0)
    };

    void Awake() => SaveFilePath = Application.persistentDataPath + "/save-data.json";

    public void InitialiseSaveData() => InitialSaveData.ForEach(SaveLevel);

    public void SaveLevel(string levelId, int highScore, bool force = false)
    {
        List<SerializableLevel> levels = LoadSaveData();
        SerializableLevel level = levels.Find(level => level.Id == levelId);

        if (level != null)
        {
            if (level.HighScore < highScore || force)
            {
                level.HighScore = highScore;
            }
        }
        else
        {
            level = new SerializableLevel(levelId, highScore);
            levels.Add(level);
        }

        var saveData = new SaveData(levels);
        var json = JsonUtility.ToJson(saveData);

        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            using var fileStream = new FileStream(SaveFilePath, FileMode.Create);
            using var streamWriter = new StreamWriter(fileStream);

            streamWriter.Write(json);
        }
        else
        {
            PlayerPrefs.SetString("save-data", json);
            PlayerPrefs.Save();
        }
    }

    public List<SerializableLevel> LoadSaveData()
    {
        if (File.Exists(SaveFilePath))
        {
            string json;

            if (Application.platform != RuntimePlatform.WebGLPlayer)
            {
                using var streamReader = new StreamReader(SaveFilePath);
                json = streamReader.ReadToEnd();
            }
            else
            {
                json = PlayerPrefs.GetString("save-data");
            }

            var saveData = JsonUtility.FromJson<SaveData>(json);

            return saveData.Levels;
        }

        return new();
    }

    private void SaveLevel(SerializableLevel level) => SaveLevel(level.Id, level.HighScore, true);
}
