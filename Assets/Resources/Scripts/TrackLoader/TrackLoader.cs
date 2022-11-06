using System.Collections.Generic;
using UnityEngine;

public class TrackLoader : MonoBehaviour
{
    public NoteFactory NoteFactory;

    public Conductor Conductor;

    void Start()
    {
        List<NoteDescription> noteDescriptions = ParseTrackFile();
        List<GameObject> notes = ParseNoteDescriptions(noteDescriptions);

        Conductor.StartPlaying(notes);
    }

    private List<NoteDescription> ParseTrackFile()
    {
        return new List<NoteDescription> {
            new NoteDescription("tap", "up", 1, null),
            new NoteDescription("tap", "right", 2, null),
            new NoteDescription("tap", "down", 3, null),
            new NoteDescription("tap", "left", 4, null),
            new NoteDescription("chord", null, 5, new() { "up", "right", "left" })
        };
    }

    private List<GameObject> ParseNoteDescriptions(List<NoteDescription> noteDescriptions)
    {
        List<GameObject> notes = new();

        for (int i = 0; i < noteDescriptions.Count; i++)
        {
            NoteDescription noteDescription = noteDescriptions[i];
            GameObject note = NoteFactory.CreateNote(noteDescription);
            note.transform.position = new Vector3(noteDescription.Time * 100, note.transform.position.y, note.transform.position.z);

            notes.Add(note);
        }

        return notes;
    }
}
