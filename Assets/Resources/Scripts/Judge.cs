using System.Collections;
using System.Collections.Generic;
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

    private float TotalScore = 0;

    public void Score(float distanceFromCentre)
    {
        if (IsPerfect(distanceFromCentre))
        {
            TotalScore += PerfectScore;
            ScoreSounder.PlayOneShot(PerfectSound);
        }
        else if (IsGood(distanceFromCentre))
        {
            TotalScore += GoodScore;
            ScoreSounder.PlayOneShot(GoodSound);
        }
        else if (IsOkay(distanceFromCentre))
        {
            TotalScore += OkayScore;
            ScoreSounder.PlayOneShot(OkaySound);
        }
        else
        {
            TotalScore += MissScore;
            ScoreSounder.PlayOneShot(MissSound);
        }
    }

    private bool IsPerfect(float distanceFromCentre)
    {
        return distanceFromCentre < 0.5;
    }

    private bool IsGood(float distanceFromCentre)
    {
        return distanceFromCentre < 0.75;
    }

    private bool IsOkay(float distanceFromCentre)
    {
        return distanceFromCentre <= 1;
    }
}
