using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Saver : MonoBehaviour
{
    private string SaveFilePath;

    void Awake() => SaveFilePath = Application.persistentDataPath + "/save-data.json";

    public void SaveLevel(string levelId, int highScore)
    {
        List<SerializableLevel> levels = new();

        if (HasSaveData())
        {
            levels = LoadAllLevels();

            SerializableLevel level = levels.Find(level => level.Id == levelId);

            if (level != null && level.HighScore < highScore)
            {
                level.HighScore = highScore;
            }
            else
            {
                level = new SerializableLevel(levelId, highScore);
                levels.Add(level);
            }
        }
        else
        {
            SerializableLevel level = new SerializableLevel(levelId, highScore);
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

    public List<SerializableLevel> LoadAllLevels()
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

    public void DeleteSaveData()
    {
        if (HasSaveData())
        {
            if (Application.platform != RuntimePlatform.WebGLPlayer)
            {
                File.Delete(Application.persistentDataPath + "/save-data.json");
            }
            else
            {
                PlayerPrefs.DeleteKey("save-data");
            }
        }
    }

    private static bool HasSaveData()
    {
        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            return File.Exists(Application.persistentDataPath + "/save-data.json");
        }
        else
        {
            return PlayerPrefs.GetString("save-data") != "";
        }
    }
}
