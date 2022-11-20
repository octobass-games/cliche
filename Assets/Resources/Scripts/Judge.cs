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

    public int Combo;

    public Conductor Conductor;
    public Animator Enemy;

    public WordPopup WordPopup;
    public SummaryPanel SummaryPanel;
    public CharacterAnimatorController CharacterAnimatorController;

    private int TotalScore = 0;
    private int LongestCombo;

    public EffectCreator EffectCreator;
    public LevelManager LevelManager;
    
    public void CompleteLevel(string levelId) {
        Debug.Log("Setting high score and rendering panel");
        LevelManager.SetHighScore(levelId, TotalScore);
        SummaryPanel.RenderSummary(PerfectCount, GoodCount, OkayCount, MissCount, LongestCombo, TotalScore);
    }

    public bool PassJudgement(TargetStrikeResult targetStrikeResult)
    {
        if (targetStrikeResult.Note == null)
        {
            ResetCombo();
            return false;
        }
        else
        {
            Combo += 1;
            WordPopup.DisplayCombo(Combo);
            CharacterAnimatorController.RandomDance();

            var distanceFromCentre = targetStrikeResult.DistanceFromCentre;
            var note = targetStrikeResult.Note.GetComponentInChildren<Note>();

            ChordNote chordNote = targetStrikeResult.Note.GetComponent<ChordNote>();

            if (chordNote != null)
            {
                if (chordNote.IsFinished())
                {
                    if (IsPerfect(distanceFromCentre))
                    {
                        Score(PerfectScore);
                        WordPopup.Perfect();
                        note.SetPerfectCollided();
                        EffectCreator.MakeEffect();
                        PerfectCount += 1;
                    }
                    else if (IsGood(distanceFromCentre))
                    {
                        Score(GoodScore);
                        WordPopup.Good();
                        note.SetGoodCollided();
                        EffectCreator.MakeEffect();
                        GoodCount += 1;
                    }
                    else if (IsOkay(distanceFromCentre))
                    {
                        Score(OkayScore);
                        WordPopup.Okay();
                        note.SetOkayCollided();
                        EffectCreator.MakeEffect();
                        OkayCount += 1;
                    }
                }
            }
            else
            {
                if (IsPerfect(distanceFromCentre))
                {
                    Score(PerfectScore);
                    WordPopup.Perfect();
                    note.SetPerfectCollided();
                    EffectCreator.MakeEffect();
                    PerfectCount += 1;
                }
                else if (IsGood(distanceFromCentre))
                {
                    Score(GoodScore);
                    WordPopup.Good();
                    note.SetGoodCollided();
                    EffectCreator.MakeEffect();
                    GoodCount += 1;
                }
                else if (IsOkay(distanceFromCentre))
                {
                    Score(OkayScore);
                    WordPopup.Okay();
                    note.SetOkayCollided();
                    EffectCreator.MakeEffect();
                    OkayCount += 1;
                }
            }

            return true;
        }
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
        ResetCombo();
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

    private void ResetCombo()
    {
        if (LongestCombo < Combo)
        {
            LongestCombo = Combo;
        }

        Combo = 0;
        WordPopup.StopCombo();
    }


    IEnumerator EnemyHitAfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        Enemy.SetTrigger("hit");

    }
}
