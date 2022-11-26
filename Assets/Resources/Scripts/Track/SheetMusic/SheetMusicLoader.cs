using System.Collections.Generic;
using UnityEngine;

public class SheetMusicLoader : MonoBehaviour
{
    public NoteFactory NoteFactory;

    public SheetMusic Read(string pathToSheetMusic, bool standardDifficulty) => ParseSheetMusic(pathToSheetMusic, standardDifficulty);

    private SheetMusic ParseSheetMusic(string PathToSheetMusic, bool standardDifficulty)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(PathToSheetMusic);

        var noteDescriptions = JsonUtility.FromJson<NoteDescriptions>(textAsset.text);

        if (standardDifficulty)
        {
            MakeStandardDifficulty(noteDescriptions);
        }

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

    private void MakeStandardDifficulty(NoteDescriptions noteDescriptions)
    {
        List<NoteDescription> descriptions = noteDescriptions.Descriptions;

        for (int i = 0; i <descriptions.Count; i++)
        {
            NoteDescription description = descriptions[i];

            if (description.Type == "chord")
            {
                description.Type = "tap";
                description.Name = description.Names[0];
                description.Names = null;
            }
        }
    }
}
