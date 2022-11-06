using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFactory : MonoBehaviour
{
    public GameObject TapNotePrefab;
    public GameObject ChordNotePrefab;

    public GameObject UpNotePrefab;
    public GameObject RightNotePrefab;
    public GameObject DownNotePrefab;
    public GameObject LeftNotePrefab;

    public GameObject CreateNote(NoteDescription noteDescription)
    {
        GameObject note;

        if (noteDescription.Type == "tap")
        {
            note = CreateTapNote(noteDescription);
        }
        else
        {
            note = CreateChordNote(noteDescription);
        }
        
        note.transform.position = new Vector3(noteDescription.Time * 100, note.transform.position.y, note.transform.position.z);

        return note;
    }

    private GameObject CreateTapNote(NoteDescription noteDescription)
    {
        GameObject tapNote = Instantiate(TapNotePrefab);

        GameObject notePrefab = GetPrefabByNoteName(noteDescription.Name);
        GameObject note = Instantiate(notePrefab);
        note.transform.SetParent(tapNote.transform);
        note.AddComponent<TapNote>();

        return tapNote;
    }

    private GameObject CreateChordNote(NoteDescription noteDescription)
    {
        GameObject chord = Instantiate(ChordNotePrefab);

        List<GameObject> chordNotes = noteDescription.Names.ConvertAll(name =>
        {
            GameObject namePrefab = GetPrefabByNoteName(name);

            return Instantiate(namePrefab);
        });

        chordNotes.ForEach(chordNote =>
        {
            chordNote.transform.SetParent(chord.transform);
            chordNote.AddComponent<TapNote>();
        });

        return chord;
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
