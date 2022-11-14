using System.Collections;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public int PerfectScore = 100;
    public int GoodScore = 50;
    public int OkayScore = 25;
    public int MissScore = 0;

    public Conductor Conductor;
    public Animator Enemy;

    public WordPopup WordPopup;

    private float TotalScore = 0;

    public EffectCreator EffectCreator;

    public bool PassJudgement(TargetStrikeResult targetStrikeResult)
    {
        var distanceFromCentre = targetStrikeResult.DistanceFromCentre;
        Debug.Log("distanceFromCentre "+ distanceFromCentre);
        var note = targetStrikeResult.Note.GetComponentInChildren<Note>();

        if (IsPerfect(distanceFromCentre))
        {
            Score(PerfectScore);
            WordPopup.Perfect();
            note.SetPerfectCollided();
            EffectCreator.MakeEffect();
            return true;
        }
        else if (IsGood(distanceFromCentre))
        {
            Score(GoodScore);
            WordPopup.Good();
            note.SetGoodCollided();
            EffectCreator.MakeEffect();
            return true;
        }
        else if (IsOkay(distanceFromCentre))
        {
            Score(OkayScore);
            WordPopup.Okay();
            note.SetOkayCollided();
            EffectCreator.MakeEffect();
            return true;
        }
        return false;
    }

    private void Score(int score)
    {
        TotalScore += score;
        Debug.Log("Score: " + score + ", Total score: " + TotalScore);
        StartCoroutine(EnemyHitAfterTime());
    }

    private bool IsPerfect(float distanceFromNextNote)
    {
        return distanceFromNextNote < 3;
    }

    private bool IsGood(float distanceFromNextNote)
    {
        return distanceFromNextNote < 5;
    }

    private bool IsOkay(float distanceFromNextNote)
    {
        return distanceFromNextNote <= 10;
    }


    IEnumerator EnemyHitAfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        Enemy.SetTrigger("hit");

    }
}
