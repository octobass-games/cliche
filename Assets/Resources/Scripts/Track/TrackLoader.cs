using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TrackLoader : MonoBehaviour
{
    public int BeatsPerMinute;
    public int DistancePerBeat;
    public NoteFactory NoteFactory;
    public Conductor Conductor;
    public string PathToMusicChart;

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

        Debug.Log(beatsPerSecond);
        Debug.Log(secondsPerBeat);
        Debug.Log(DistancePerBeat / secondsPerBeat);

        return DistancePerBeat / secondsPerBeat;
    }

    private List<GameObject> ParseTrackFile()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(PathToMusicChart);

        Debug.Log(textAsset.text);

        var noteDescriptions = JsonUtility.FromJson<NoteDescriptions>(textAsset.text);

        Debug.Log(noteDescriptions);
        Debug.Log(noteDescriptions.Descriptions);

 /*       List<NoteDescription> noteDescriptions = new() {
            new NoteDescription("tap", "up", 2.5f, null),
            new NoteDescription("tap", "right", 2.8f, null),
            new NoteDescription("tap", "down", 3, null),
            new NoteDescription("tap", "left", 4, null),
            new NoteDescription("chord", null, 5, new() { "up", "right", "left" })
        };*/
        
        return ParseNoteDescriptions(noteDescriptions.Descriptions);
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
