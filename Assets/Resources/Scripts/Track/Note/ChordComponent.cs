using UnityEngine;

public class ChordComponent : MonoBehaviour
{
    public Note Note;
    public bool Played = false;

    public void Play()
    {
        Played = true;
    }
}
