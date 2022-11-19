public struct DialougeLine
{
    public DialougeLine(string speaker, string line, string trigger)
    {
        Speaker = speaker;
        Line = line;
        Trigger = trigger;
    }

    public string Line { get; }
    public string Speaker { get; }
    public string Trigger { get; }
}
