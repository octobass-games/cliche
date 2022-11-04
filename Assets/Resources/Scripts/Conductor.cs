using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public GameObject NotePrefab;
    public NoteType2[] NoteTimes = { new NoteType2(NoteType.UP, 1), new NoteType2(NoteType.RIGHT, 2), new NoteType2(NoteType.DOWN, 3), new NoteType2(NoteType.LEFT, 4) };
    public CharacterAnimatorController CharacterAnimatorController;
    public Judge Judge;
    public TrackHighway TrackHighway;

    public float BeatsPerSecond;
    private List<Note> Notes = new();

    void Start()
    {
        CreateNotes();
    }

    void Update()
    {
        MoveNotes();
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

    private void CreateNotes()
    {
        for (int i = 0; i < NoteTimes.Length; i++)
        {
            NoteType2 noteLocation = NoteTimes[i];

            GameObject note = Instantiate(NotePrefab);
            Note noteComponent = note.GetComponent<Note>();
            noteComponent.InitialX = noteLocation.Time * 100;
            noteComponent.NoteType = noteLocation.Type;

            Notes.Add(note.GetComponent<Note>());
        }

        TrackHighway.PlaceNotes(Notes);
    }

    private void MoveNotes()
    {
        for (int i = 0; i < Notes.Count; i++)
        {
            Note note = Notes[i];
            Vector3 displacement = BeatsPerSecond * Vector3.left * Time.deltaTime;
            note.transform.position = note.transform.position + displacement;
        }
    }
}
