using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public GameObject NotePrefab;
    public float[] NoteTimes = { 1, 2, 3 };

    public float BeatsPerSecond;
    private List<Note> Notes = new();
    public List<Target> Targets;

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
            MissedNote();
        } else
        {
            Debug.Log("Note played correctly");
        }
    }

    public void MissedNote()
    {
        GameObject note = Notes[0].gameObject;
        Notes.RemoveAt(0);
        Destroy(note);
    }

    private void CreateNotes()
    {
        for (int i = 0; i < NoteTimes.Length; i++)
        {
            float noteLocation = NoteTimes[i] * 100;

            GameObject note = Instantiate(NotePrefab);

            note.transform.SetParent(transform);
            note.transform.position = new Vector3(noteLocation, transform.position.y, 0);

            Notes.Add(note.GetComponent<Note>());
        }
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
