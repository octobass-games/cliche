using UnityEngine;

public class ChordNote : MonoBehaviour
{
    public bool IsFinished()
    {
        TapNote[] tapNotes = GetTapNotes();

        bool IsFinished = false;

        for (int i = 0; i < tapNotes.Length; i++)
        {
            if (!tapNotes[i].Played)
            {
                return false;
            }
        }

        return true;
    }

    public TapNote[] GetTapNotes() =>  GetComponentsInChildren<TapNote>();
}
