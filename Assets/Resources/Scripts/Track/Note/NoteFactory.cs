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
    public Transform UpTarget;
    public Transform RightTarget;
    public Transform DownTarget;
    public Transform LeftTarget;

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
        GameObject tapNote = new GameObject();
        GameObject notePrefab = GetPrefabByNoteName(noteDescription.Name);
        GameObject note = Instantiate(notePrefab);
        note.transform.SetParent(tapNote.transform);
        note.AddComponent<TapNote>();
        SetNotePosition(noteDescription.Name, note, noteDescription.Time);

        return tapNote;
    }

    private GameObject CreateChordNote(NoteDescription noteDescription)
    {
        GameObject chord = Instantiate(ChordNotePrefab);

        noteDescription.Names.ForEach(name =>
        {
            GameObject prefab = GetPrefabByNoteName(name);
            GameObject chordNote = Instantiate(prefab);
            chordNote.transform.SetParent(chord.transform);
            chordNote.AddComponent<TapNote>();
            SetNotePosition(name, chordNote, noteDescription.Time);
        });

        return chord;
    }

    private void SetNotePosition(string name, GameObject note, float time)
    {
        var pos = GetTargetPositionByNoteName(name);
        var halfWidthOfTarget = 10;
        note.transform.position = new Vector3(time * 100 + pos.x + halfWidthOfTarget, pos.y, note.transform.position.z);
    }

    private Vector2 GetTargetPositionByNoteName(string name)
    {
        switch (name)
        {
            case "up":
                return UpTarget.position;
            case "right":
                return RightTarget.position;
            case "down":
                return DownTarget.position;
            case "left":
                return LeftTarget.position;
            default:
                throw new System.Exception("Illegal note type: " + name);
        }
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
