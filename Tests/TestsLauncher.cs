using Tests;

class TestLauncher
{
    static void Main()
    {
        bool IsPassed = true;

        MyTests.ItalicTest(ref IsPassed);
        MyTests.BoldTest(ref IsPassed);
        MyTests.MonospacedTest(ref IsPassed);
        MyTests.PreformatedTest(ref IsPassed);
        MyTests.ParagraphTest(ref IsPassed);
        MyTests.HTMLStructureTest(ref IsPassed);
        MyTests.SummaryTest(ref IsPassed);

        if (IsPassed)
        {
            Environment.Exit(0);
        }
        else
        {
            Environment.Exit(1);
        }
    }
}
