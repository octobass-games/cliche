using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string SaveFilePath;

    void Awake() => SaveFilePath = Application.persistentDataPath + "/save-data.json";

    public void Save(List<Level> levels)
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

    public List<Level> Load()
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
    public bool HasSaveData()
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
