using System.Collections.Generic;
using UnityEngine;

public class TrackLoader : MonoBehaviour
{
    public GameObject UpNotePrefab;
    public GameObject RightNotePrefab;
    public GameObject DownNotePrefab;
    public GameObject LeftNotePrefab;

    public Conductor Conductor;

    void Start()
    {
        List<NoteDescription> noteDescriptions = ParseTrackFile();
        List<GameObject> notes = ParseNoteDescriptions(noteDescriptions);

        Conductor.Start(notes);
    }

    private List<NoteDescription> ParseTrackFile()
    {
        return new List<NoteDescription> {
            new NoteDescription("up", 1),
            new NoteDescription("right", 2),
            new NoteDescription("down", 3),
            new NoteDescription("left", 4)
        };
    }

    private List<GameObject> ParseNoteDescriptions(List<NoteDescription> noteDescriptions)
    {
        List<GameObject> notes = new();

        for (int i = 0; i < noteDescriptions.Count; i++)
        {
            NoteDescription noteDescription = noteDescriptions[i];
            GameObject prefabForNoteDescription = GetPrefabByNoteName(noteDescription.Name);

            GameObject note = Instantiate(prefabForNoteDescription);
            note.transform.position = new Vector3(noteDescription.Time * 100, note.transform.position.y, note.transform.position.z);

            notes.Add(note);
        }

        return notes;
    }

    private GameObject GetPrefabByNoteName(string noteName)
    {
        switch (noteName)
        {
            case "up":
                return UpNotePrefab;
            case "right":
                return RightNotePrefab;
            case "down":
                return DownNotePrefab;
            case "left":
                return LeftNotePrefab;
            default:
                throw new System.Exception("Illegal note type: " + noteName);
        }
    }
}
