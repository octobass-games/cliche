public struct DialougeLine
{
    public DialougeLine(string speaker, string line)
    {
        Speaker = speaker;
        Line = line;
    }

    public string Line { get; }
    public string Speaker { get; }
}
