[System.Serializable]
public class SerializableLevel
{
    public string Id;
    public int EasyHighScore;
    public int NormalHighScore;
    public int HardHighScore;
    public Medal EasyMedal;
    public Medal NormalMedal;
    public Medal HardMedal;
    public LevelState State;
    public int SilverScore;
    public int GoldScore;

    public SerializableLevel(
        string id,
        LevelState state,
        int easyHighScore,
        int normalHighScore,
        int hardHighScore,
        int silverScore,
        int goldScore,
        Medal easyMedal = Medal.BRONZE,
        Medal normalMedal = Medal.BRONZE,
        Medal hardMedal = Medal.BRONZE
        )
    {
        Id = id;
        State = state;
        EasyHighScore = easyHighScore;
        NormalHighScore = normalHighScore;
        HardHighScore = hardHighScore;
        SilverScore = silverScore;
        GoldScore = goldScore;
        EasyMedal = easyMedal;
        NormalMedal = normalMedal;
        HardMedal = hardMedal;
    }
}
