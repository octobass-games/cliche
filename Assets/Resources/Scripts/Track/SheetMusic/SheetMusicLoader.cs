using System.Collections.Generic;
using UnityEngine;

public class SheetMusicLoader : MonoBehaviour
{
    public NoteFactory NoteFactory;

    public SheetMusic Read(string pathToSheetMusic)
    {
        return ParseSheetMusic(pathToSheetMusic);
    }

    private SheetMusic ParseSheetMusic(string PathToSheetMusic)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(PathToSheetMusic);

        var noteDescriptions = JsonUtility.FromJson<NoteDescriptions>(textAsset.text);
        var notes = ParseNoteDescriptions(noteDescriptions.Descriptions);

        return new SheetMusic(notes);
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
