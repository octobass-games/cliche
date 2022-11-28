[System.Serializable]
public class Level
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

    public Level(
        string id,
        LevelState state,
        int easyHighScore,
        int normalHighScore,
        int hardHighScore,
        int silverScore,
        int goldScore,
        Medal easyMedal = Medal.NONE,
        Medal normalMedal = Medal.NONE,
        Medal hardMedal = Medal.NONE
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
