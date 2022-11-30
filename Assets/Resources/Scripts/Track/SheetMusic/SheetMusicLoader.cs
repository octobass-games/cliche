using System.Collections.Generic;
using UnityEngine;

public class SheetMusicLoader : MonoBehaviour
{
    public NoteFactory NoteFactory;

    public SheetMusic Read(string pathToSheetMusic, Difficulty difficulty) => ParseSheetMusic(pathToSheetMusic, difficulty);

    private SheetMusic ParseSheetMusic(string PathToSheetMusic, Difficulty difficulty)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(PathToSheetMusic);

        var noteDescriptions = JsonUtility.FromJson<NoteDescriptions>(textAsset.text);

        if (difficulty == Difficulty.EASY)
        {
            MakeEasyDifficulty(noteDescriptions);
        }
        else if (difficulty == Difficulty.NORMAL)
        {
            MakeNormalDifficulty(noteDescriptions);
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

    private void MakeEasyDifficulty(NoteDescriptions noteDescriptions)
    {
        List<NoteDescription> descriptions = noteDescriptions.Descriptions;

        for (int i = 0; i < descriptions.Count; i++)
        {
            NoteDescription description = descriptions[i];

            if (description.Type == "chord")
            {
                description.Type = "tap";
                description.Names = null;
            }

            description.Name = GetDirectionForTime(description.Time);
        }
    }

    private void MakeNormalDifficulty(NoteDescriptions noteDescriptions)
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

    private string GetDirectionForTime(float time) => NoteFactory.NoteNames[((int) (time / 3)) % NoteFactory.NoteNames.Count];
}
