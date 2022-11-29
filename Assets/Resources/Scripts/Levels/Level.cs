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

    public Level(
        string id,
        LevelState state,
        int easyHighScore = 0,
        int normalHighScore = 0,
        int hardHighScore = 0,
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
        EasyMedal = easyMedal;
        NormalMedal = normalMedal;
        HardMedal = hardMedal;
    }
}
