[System.Serializable]
public class SerializableLevel
{
    public string Id;
    public int HighScore;
    public LevelState State;

    public SerializableLevel(string id, int highScore, LevelState state)
    {
        Id = id;
        HighScore = highScore;
        State = state;
    }
}
