using System.Collections.Generic;

public struct NoteDescription
{
    public NoteDescription(string type, string name, float time, List<string> names)
    {
        Type = type;
        Name = name;
        Time = time;
        Names = names;
    }

    public string Type { get; }
    public string Name { get; }
    public float Time { get; }
    public List<string> Names { get; }
}
