using System.Collections.Generic;
using UnityEngine;

public class TrackLoader : MonoBehaviour
{
    public int BeatsPerMinute;
    public int DistancePerBeat;
    public NoteFactory NoteFactory;
    public Conductor Conductor;

    void Start()
    {
        float trackVelocity = CalculateTrackVelocity();

        List<GameObject> notes = ParseTrackFile();

        Conductor.StartPlaying(notes, trackVelocity);
    }

    private float CalculateTrackVelocity()
    {
        float beatsPerSecond = BeatsPerMinute / 60f;
        float secondsPerBeat = 1 / beatsPerSecond;

        return DistancePerBeat * secondsPerBeat;
    }

    private List<GameObject> ParseTrackFile()
    {
        List<NoteDescription> noteDescriptions = new() {
            new NoteDescription("tap", "up", 1.5f, null),
            new NoteDescription("tap", "right", 2, null),
            new NoteDescription("tap", "down", 3, null),
            new NoteDescription("tap", "left", 4, null),
            new NoteDescription("chord", null, 5, new() { "up", "right", "left" })
        };
        
        return ParseNoteDescriptions(noteDescriptions);
    }

    private List<GameObject> ParseNoteDescriptions(List<NoteDescription> noteDescriptions)
    {
        List<GameObject> notes = new();

        for (int i = 0; i < noteDescriptions.Count; i++)
        {
            NoteDescription noteDescription = noteDescriptions[i];

            GameObject note = NoteFactory.CreateNote(noteDescription);

            notes.Add(note);
        }

        return notes;
    }
}
