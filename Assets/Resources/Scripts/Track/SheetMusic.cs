using System.Collections.Generic;
using UnityEngine;

public class SheetMusic
{
    public int BeatsPerMinute;
    public List<GameObject> Notes;

    public SheetMusic(int beatsPerMinute, List<GameObject> notes)
    {
        BeatsPerMinute = beatsPerMinute;
        Notes = notes;
    }
}
