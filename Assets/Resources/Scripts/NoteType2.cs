public struct NoteType2
{
    public NoteType2(NoteType type, int time)
    {
        Type = type;
        Time = time;
    }

    public NoteType Type { get; }
    public int Time { get; }
}
