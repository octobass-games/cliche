[System.Serializable]
public class SerializableLevel
{
    public string Id;
    public int HighScore;
    public Medal Medal;
    public LevelState State;
    public int SilverScore;
    public int GoldScore;

    public SerializableLevel(string id, LevelState state, int highScore, int silverScore, int goldScore, Medal medal = Medal.BRONZE)
    {
        Id = id;
        State = state;
        HighScore = highScore;
        SilverScore = silverScore;
        GoldScore = goldScore;
        Medal = medal;
    }
}
