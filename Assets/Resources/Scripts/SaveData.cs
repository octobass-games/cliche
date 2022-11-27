using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public List<Level> Levels;

    public SaveData(List<Level> levels)
    {
        Levels = levels;
    }
}
