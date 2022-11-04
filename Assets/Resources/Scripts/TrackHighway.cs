using System.Collections.Generic;
using UnityEngine;

public class TrackHighway : MonoBehaviour
{
    public float UpYCoord;
    public float RightYCoord;
    public float DownYCoord;
    public float LeftYCoord;

    public void PlaceNotes(List<Note> notes)
    {
        for (int i = 0; i < notes.Count; i++)
        {
            Note note = notes[i];

            note.transform.SetParent(transform);
            note.transform.position = new Vector3(note.InitialX, GetYCoordForNoteType(note.NoteType), 0);
        }
    }

    private float GetYCoordForNoteType(NoteType noteType)
    {
        switch (noteType)
        {
            case NoteType.UP:
                return UpYCoord;
            case NoteType.RIGHT:
                return RightYCoord;
            case NoteType.DOWN:
                return DownYCoord;
            case NoteType.LEFT:
                return LeftYCoord;
            default:
                throw new System.Exception("Invalid NoteType");
        }
    }
}
