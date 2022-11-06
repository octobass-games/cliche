using UnityEngine;

public class ChordNote : MonoBehaviour
{
    public bool IsFinished()
    {
        TapNote[] tapNotes = GetComponentsInChildren<TapNote>();

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
}
