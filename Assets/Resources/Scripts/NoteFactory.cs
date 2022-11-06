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
        if (noteDescription.Type == "tap")
        {
            return CreateTapNote(noteDescription);
        }
        else
        {
            return CreateChordNote(noteDescription);
        }
    }

    private GameObject CreateTapNote(NoteDescription noteDescription)
    {
        GameObject tapNote = Instantiate(TapNotePrefab);

        GameObject notePrefab = GetPrefabByNoteName(noteDescription.Name);
        GameObject note = Instantiate(notePrefab);
        note.transform.SetParent(tapNote.transform);

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
