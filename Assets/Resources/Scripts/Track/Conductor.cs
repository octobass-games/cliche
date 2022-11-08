using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public GameObject Track;
    public CharacterAnimatorController CharacterAnimatorController;
    public Judge Judge;
    public int Combo;

    public List<GameObject> Notes = new();
    public float Velocity = 0;

    void Update()
    {
        MoveNotes();
    }

    public void StartPlaying(List<GameObject> notes, float trackVelocity)
    {
        Notes = notes;
        Velocity = trackVelocity;

        notes.ForEach(note => note.transform.SetParent(Track.transform));
    }

    public void PlayedNote(TargetStrikeResult targetStrikeResult)
    {
        if (targetStrikeResult.Note == null)
        {
            Debug.Log("Uh oh!");
        }
        else
        {
            ChordNote chordNote = targetStrikeResult.Note.GetComponent<ChordNote>();

            if (chordNote != null)
            {
                if (chordNote.IsFinished())
                {
                    HitNote(targetStrikeResult);
                }
            }
            else
            {
                HitNote(targetStrikeResult);
            }
        }
    }

    private void HitNote(TargetStrikeResult targetStrikeResult)
    {
        Combo += 1;
        Debug.Log("Current combo: " + Combo);
        CharacterAnimatorController.RandomDance();
        Judge.PassJudgement(targetStrikeResult);
        RemoveNote();
    }

    public void MissedNote()
    {
        Combo = 0;
        RemoveNote();
    }

    private void RemoveNote()
    {
        GameObject note = Notes[0].gameObject;
        Notes.RemoveAt(0);
        Destroy(note);
    }

    private void MoveNotes()
    {
        Vector3 displacement = Velocity * Vector3.left * Time.deltaTime;
        Track.transform.position = Track.transform.position + displacement;
    }
}
