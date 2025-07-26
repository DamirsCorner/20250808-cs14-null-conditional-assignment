using Shouldly;

namespace Cs14NullConditionalAssignment;

public class BeforeCs14Tests
{
    [Test]
    public void AccessingMemberOfNullThrows()
    {
        Report? report = null;

        Should.Throw<NullReferenceException>(() => report.ItemsProcessed);
    }

    [Test]
    public void NullConditionalAccessingMemberOfNullDoesNotThrow()
    {
        Report? report = null;

        (report?.ItemsProcessed).ShouldBeNull();
    }

    [Test]
    public void AccessingElementOfNullThrows()
    {
        List<int>? list = null;

        Should.Throw<NullReferenceException>(() => list[0]);
    }

    [Test]
    public void NullConditionalAccessingElementOfNullDowNotThrow()
    {
        List<int>? list = null;

        (list?[0]).ShouldBeNull();
    }

    [Test]
    public void AssignmentToNonNullMemberSucceedsAndExecutes()
    {
        Processor processor = new();
        Report? report = new();

        report.ItemsProcessed = processor.Process();

        report.ShouldNotBeNull();
        report.ItemsProcessed.ShouldBe(42);

        processor.Processed.ShouldBe(true);
    }

    [Test]
    public void AssignmentToNullMemberThrowsButExecutes()
    {
        Processor processor = new();
        Report? report = null;

        Should.Throw<NullReferenceException>(() => report.ItemsProcessed = processor.Process());

        report.ShouldBeNull();
        (report?.ItemsProcessed).ShouldBeNull();

        processor.Processed.ShouldBe(true);
    }

    [Test]
    public void AssignmentInSkippedIfBlockDoesNotThrowOrExecute()
    {
        Processor processor = new();
        Report? report = null;

        if (report != null)
        {
            report.ItemsProcessed = processor.Process();
        }

        report.ShouldBeNull();
        (report?.ItemsProcessed).ShouldBeNull();

        processor.Processed.ShouldBe(false);
    }
}
