namespace Cs14NullConditionalAssignment;

public class Processor
{
    public bool Processed { get; private set; } = false;

    public int Process()
    {
        Processed = true;
        return 42;
    }
}
