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

    public void PassJudgement()
    {
        float distanceFromNextNote = Conductor.GetDistanceFromNextNote();

        if (IsPerfect(distanceFromNextNote))
        {
            Score(PerfectScore, PerfectSound);
        }
        else if (IsGood(distanceFromNextNote))
        {
            Score(GoodScore, GoodSound);
        }
        else if (IsOkay(distanceFromNextNote))
        {
            Score(OkayScore, OkaySound);
        }
        else
        {
            Score(MissScore, MissSound);
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
