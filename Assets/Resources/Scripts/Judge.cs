using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private int Multiplier = 1;

    public EffectCreator EffectCreator;

    public Animator TargetCircleUpAnimator;
    public Animator TargetCircleDownAnimator;
    public Animator TargetCircleLeftAnimator;
    public Animator TargetCircleRightAnimator;

    public void CompleteLevel(string levelId)
    {
        Debug.Log("Setting high score and rendering panel");
        Medal medal = GameManager.Instance.LevelManager.SetHighScore(levelId, TotalScore, Conductor.Difficulty);

        if (Combo > LongestCombo)
        {
            LongestCombo = Combo;
        }

        SummaryPanel.RenderSummary(PerfectCount, GoodCount, OkayCount, MissCount, LongestCombo, TotalScore, medal, Conductor.Difficulty);
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
            var distanceFromCentre = targetStrikeResult.DistanceFromCentre;
            var notes = targetStrikeResult.Note.GetComponentsInChildren<Note>().ToList();

            ChordNote chordNote = targetStrikeResult.Note.GetComponent<ChordNote>();

            if (chordNote != null)
            {
                if (chordNote.IsFinished())
                {
                    if (IsPerfect(distanceFromCentre))
                    {
                        Score(PerfectScore, notes);
                        WordPopup.Perfect();
                        notes.ForEach(n => n.SetPerfectCollided());
                        PerfectCount += 1;
                    }
                    else if (IsGood(distanceFromCentre))
                    {
                        Score(GoodScore, notes);
                        WordPopup.Good();
                        notes.ForEach(n => n.SetGoodCollided());
                        GoodCount += 1;
                    }
                    else
                    {
                        Score(OkayScore, notes);
                        WordPopup.Okay();
                        notes.ForEach(n => n.SetOkayCollided());
                        OkayCount += 1;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                var note = notes[0];

                if (IsPerfect(distanceFromCentre))
                {
                    Score(PerfectScore, notes);
                    WordPopup.Perfect();
                    note.SetPerfectCollided();
                    PerfectCount += 1;
                }
                else if (IsGood(distanceFromCentre))
                {
                    Score(GoodScore, notes);
                    WordPopup.Good();
                    note.SetGoodCollided();
                    GoodCount += 1;
                }
                else
                {
                    Score(OkayScore, notes);
                    WordPopup.Okay();
                    note.SetOkayCollided();
                    OkayCount += 1;
                    return true;
                }
            }
            return true;

        }
    }

    private void Score(int score, List<Note> notes)
    {
        Combo += 1;
        WordPopup.DisplayCombo(Combo);
        TotalScore += score * Multiplier;

        if (Combo == 50)
        {
            Multiplier = 2;
        }

        CharacterAnimatorController.RandomDance();

        Debug.Log("Score: " + score + ", Total score: " + TotalScore);
        WordPopup.DisplayScore(TotalScore);
        StartCoroutine(EnemyHitAfterTime());
        EffectCreator.MakeEffect();
        notes.ForEach(OnHitAnimation);
    }

    public void MissedNote()
    {
        ResetCombo();
        MissCount += 1;
    }


    private void OnHitAnimation(Note note)
    {
        switch (note.NoteType)
        {
            case NoteType.UP:
                TargetCircleUpAnimator.SetTrigger("Hit");
                break;
            case NoteType.DOWN:
                TargetCircleDownAnimator.SetTrigger("Hit");
                break;
            case NoteType.LEFT:
                TargetCircleLeftAnimator.SetTrigger("Hit");
                break;
            case NoteType.RIGHT:
                TargetCircleRightAnimator.SetTrigger("Hit");
                break;
        }
    }

    private bool IsPerfect(float distanceFromNextNote)
    {
        return distanceFromNextNote < 6;
    }

    private bool IsGood(float distanceFromNextNote)
    {
        return distanceFromNextNote < 10;
    }

    private void ResetCombo()
    {
        Debug.Log("Resetting combo: " + Combo);
        if (LongestCombo < Combo)
        {
            LongestCombo = Combo;
        }

        Multiplier = 1;
        Combo = 0;
        WordPopup.StopCombo();
    }


    IEnumerator EnemyHitAfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        if (Enemy != null)
        {
            Enemy.SetTrigger("hit");
        }
    }
}
