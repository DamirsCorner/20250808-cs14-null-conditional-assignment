using Shouldly;

namespace Cs14NullConditionalAssignment;

public class WithCs14Tests
{
    [Test]
    public void NullConditionalAssignmentToNullMemberDoesNotThrowOrExecute()
    {
        Processor processor = new();
        Report? report = null;

        report?.ItemsProcessed = processor.Process();

        report.ShouldBeNull();
        (report?.ItemsProcessed).ShouldBeNull();

        processor.Processed.ShouldBe(false);
    }

    [Test]
    public void NullConditionalAssignmentToNullElementDoesNotThrowOrExecute()
    {
        Processor processor = new();
        List<int>? list = null;

        list?[0] = processor.Process();

        list.ShouldBeNull();
        (list?[0]).ShouldBeNull();

        processor.Processed.ShouldBe(false);
    }

    [Test]
    public void NullConditionalCompoundAssignmentToNullElementDoesNotThrowOrExecute()
    {
        Processor processor = new();
        Report? report = null;

        report?.ItemsProcessed += processor.Process();

        report.ShouldBeNull();
        (report?.ItemsProcessed).ShouldBeNull();

        processor.Processed.ShouldBe(false);
    }
}
