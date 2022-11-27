using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public List<SerializableLevel> Levels;

    public SaveData(List<SerializableLevel> levels)
    {
        Levels = levels;
    }
}
