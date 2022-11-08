using UnityEngine;

public class Judge : MonoBehaviour
{
    public int PerfectScore = 100;
    public int GoodScore = 50;
    public int OkayScore = 25;
    public int MissScore = 0;

    public AudioSource ScoreSounder;

    public AudioClip PerfectSound;
    public AudioClip GoodSound;
    public AudioClip OkaySound;
    public AudioClip MissSound;

    public Conductor Conductor;

    private float TotalScore = 0;

    public void PassJudgement(TargetStrikeResult targetStrikeResult)
    {
        var distanceFromCentre = targetStrikeResult.DistanceFromCentre;
        var note = targetStrikeResult.Note.GetComponentInChildren<Note>();

        if (IsPerfect(distanceFromCentre))
        {
            Score(PerfectScore, PerfectSound);
            note.SetPerfectCollided();
        }
        else if (IsGood(distanceFromCentre))
        {
            Score(GoodScore, GoodSound);
            note.SetGoodCollided();
        }
        else if (IsOkay(distanceFromCentre))
        {
            Score(OkayScore, OkaySound);
            note.SetOkayCollided();
        }
    }

    private void Score(int score, AudioClip clip)
    {
        TotalScore += score;
        Debug.Log("Score: " + score + ", Total score: " + TotalScore);
    }

    private bool IsPerfect(float distanceFromNextNote)
    {
        return distanceFromNextNote < 0.5;
    }

    private bool IsGood(float distanceFromNextNote)
    {
        return distanceFromNextNote < 0.75;
    }

    private bool IsOkay(float distanceFromNextNote)
    {
        return distanceFromNextNote <= 1;
    }
}
