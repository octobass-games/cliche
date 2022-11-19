using System.Collections;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public int PerfectScore = 100;
    public int GoodScore = 50;
    public int OkayScore = 25;
    public int MissScore = 0;

    public int PerfectCount;
    public int GoodCount;
    public int OkayCount;
    public int MissCount;

    public Conductor Conductor;
    public Animator Enemy;

    public WordPopup WordPopup;
    public SummaryPanel SummaryPanel;
    private int TotalScore = 0;

    public EffectCreator EffectCreator;
    
    public void CompleteLevel() {
        SummaryPanel.RenderSummary(PerfectCount, GoodCount, OkayCount, MissCount, 0, TotalScore);
    }

    public bool PassJudgement(TargetStrikeResult targetStrikeResult)
    {
        var distanceFromCentre = targetStrikeResult.DistanceFromCentre;
        var note = targetStrikeResult.Note.GetComponentInChildren<Note>();

        if (IsPerfect(distanceFromCentre))
        {
            Score(PerfectScore);
            WordPopup.Perfect();
            note.SetPerfectCollided();
            EffectCreator.MakeEffect();
            PerfectCount += 1;
            return true;
        }
        else if (IsGood(distanceFromCentre))
        {
            Score(GoodScore);
            WordPopup.Good();
            note.SetGoodCollided();
            EffectCreator.MakeEffect();
            GoodCount += 1;
            return true;
        }
        else if (IsOkay(distanceFromCentre))
        {
            Score(OkayScore);
            WordPopup.Okay();
            note.SetOkayCollided();
            EffectCreator.MakeEffect();
            OkayCount += 1;
            return true;
        }
        return false;
    }

    private void Score(int score)
    {
        TotalScore += score;
        Debug.Log("Score: " + score + ", Total score: " + TotalScore);
        WordPopup.DisplayScore(TotalScore);
        StartCoroutine(EnemyHitAfterTime());
    }

    public void MissedNote()
    {
        MissCount += 1;
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
