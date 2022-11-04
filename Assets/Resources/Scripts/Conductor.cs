using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public CharacterAnimatorController CharacterAnimatorController;
    public Judge Judge;

    public float BeatsPerSecond;
    private List<GameObject> Notes = new();

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
            CharacterAnimatorController.RandomDance();
            Judge.PassJudgement(targetStrikeResult);
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
            Vector3 displacement = BeatsPerSecond * Vector3.left * Time.deltaTime;
            note.transform.position = note.transform.position + displacement;
        }
    }
}
