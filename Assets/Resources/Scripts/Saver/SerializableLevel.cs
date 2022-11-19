[System.Serializable]
public class SerializableLevel
{
    public string Id;
    public int HighScore;
    public bool IsUnlocked;

    public SerializableLevel(string id, int highScore, bool isUnlocked)
    {
        Id = id;
        HighScore = highScore;
        IsUnlocked = isUnlocked;
    }
}
