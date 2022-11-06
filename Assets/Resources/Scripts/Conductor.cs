using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public float BeatsPerMinute;
    public float DistancePerBeat;
    public CharacterAnimatorController CharacterAnimatorController;
    public Judge Judge;

    private List<GameObject> Notes = new();
    private float Velocity = 0;

    private void Start()
    {
        float BeatsPerSecond = BeatsPerMinute / 60;
        float SecondsPerBeat = 1 / BeatsPerSecond;

        Velocity = DistancePerBeat / SecondsPerBeat;
    }

    void Update()
    {
        MoveNotes();
    }

    public void StartPlaying(List<GameObject> notes)
    {
        Notes = notes;
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
                    Debug.Log("chord finished");
                }
            }
            else
            {
                CharacterAnimatorController.RandomDance();
                Judge.PassJudgement(targetStrikeResult);
            }
        }
    }

    public void MissedNote()
    {
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
        for (int i = 0; i < Notes.Count; i++)
        {
            GameObject note = Notes[i];
            Vector3 displacement = Velocity * Vector3.left * Time.deltaTime;
            note.transform.position = note.transform.position + displacement;
        }
    }
}
