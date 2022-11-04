public struct NoteDescription
{
    public NoteDescription(string name, float time)
    {
        Name = name;
        Time = time;
    }

    public string Name { get; }
    public float Time { get; }
}
