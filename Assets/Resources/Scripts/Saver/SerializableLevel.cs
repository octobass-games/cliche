[System.Serializable]
public class SerializableLevel
{
    public SerializableLevel(string id, int highScore)
    {
        Id = id;
        HighScore = highScore;
    }

    public string Id { get; }
    public int HighScore { get; set; }
}
