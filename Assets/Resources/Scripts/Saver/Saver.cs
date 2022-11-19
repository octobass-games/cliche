using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Saver : MonoBehaviour
{
    private string SaveFilePath;

    private List<SerializableLevel> InitialSaveData = new()
    {
        new SerializableLevel("", 0, false),
        new SerializableLevel("", 0, false),
        new SerializableLevel("", 0, false)
    };

    void Awake() => SaveFilePath = Application.persistentDataPath + "/save-data.json";

    public void InitialiseSaveData()
    {
        DeleteSaveData();
        Save(InitialSaveData);
    }

    public void Save(string levelId, int highScore)
    {
        List<SerializableLevel> levels = Load();
        SerializableLevel level = levels.Find(level => level.Id == levelId);

        level.IsComplete = true;

        if (level.HighScore < highScore)
        {
            level.HighScore = highScore;
        }

        Save(levels);
    }

    public List<SerializableLevel> Load()
    {
        if (HasSaveData())
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

        return null;
    }

    private void Save(List<SerializableLevel> levels)
    {
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

    private void DeleteSaveData()
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
    private bool HasSaveData()
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
