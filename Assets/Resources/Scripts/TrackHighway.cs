using System.Collections.Generic;
using UnityEngine;

public class TrackHighway : MonoBehaviour
{
    public float UpYCoord;
    public float RightYCoord;
    public float DownYCoord;
    public float LeftYCoord;

    public Sprite UpSprite;
    public Sprite RightSprite;
    public Sprite DownSprite;
    public Sprite LeftSprite;

    public void PlaceNotes(List<Note> notes)
    {
        for (int i = 0; i < notes.Count; i++)
        {
            Note note = notes[i];

            note.transform.SetParent(transform);
            note.transform.position = new Vector3(note.InitialX, GetYCoordForNoteType(note.NoteType), 0);

            note.sprite.sprite = GetSpriteForNoteType(note.NoteType);
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

    private Sprite GetSpriteForNoteType(NoteType noteType)
    {
        switch (noteType)
        {
            case NoteType.UP:
                return UpSprite;
            case NoteType.RIGHT:
                return RightSprite;
            case NoteType.DOWN:
                return DownSprite;
            case NoteType.LEFT:
                return LeftSprite;
            default:
                throw new System.Exception("Invalid NoteType");
        }
    }
}
