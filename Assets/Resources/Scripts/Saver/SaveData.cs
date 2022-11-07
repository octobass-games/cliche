using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public SaveData(List<SerializableLevel> levels)
    {
        Levels = levels;
    }

    public List<SerializableLevel> Levels { get; }
}
