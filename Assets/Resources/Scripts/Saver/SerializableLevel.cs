[System.Serializable]
public class SerializableLevel
{
    public string Id;
    public int HighScore;
    public bool IsComplete;

    public SerializableLevel(string id, int highScore, bool isComplete)
    {
        Id = id;
        HighScore = highScore;
        IsComplete = isComplete;
    }
}
