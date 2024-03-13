using Program;

namespace Tests
{
    class MyTests
    {
        public static void ItalicTest(ref bool IsPassed)
        {
            string expectedResult = @"<i>Hello_World</i>";
            string realResult = @"_Hello_World_";
            for (int i = 0; i < realResult.Length; i++)
            {
                ConverterMDtoHTML.CheckItalic(ref realResult, i);
            }

            if (realResult == expectedResult)
            {
                Console.Write("ItalicTest: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succeed");
                Console.ResetColor();
            }
            else
            {
                Console.Write("ItalicTest: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Whats wrong: ");
                Console.ResetColor();
                Console.WriteLine(realResult + " != " + expectedResult + "\n");
                IsPassed = false;
            }
        }

        public static void BoldTest(ref bool IsPassed)
        {
            string expectedResult = @"Hello <b>World</b>";
            string realResult = @"Hello **World**";

            for (int i = 0; i < realResult.Length; i++)
            {
                ConverterMDtoHTML.CheckBold(ref realResult, i);
            }

            if (realResult == expectedResult)
            {
                Console.Write("BoldTest: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succeed");
                Console.ResetColor();
            }
            else
            {
                Console.Write("BoldTest: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Whats wrong: ");
                Console.ResetColor();
                Console.WriteLine(realResult + " != " + expectedResult + "\n");
                IsPassed = false;
            }
        }

        public static void MonospacedTest(ref bool IsPassed)
        {
            string expectedResult = @"<tt>Hello World</tt>";
            string realResult = @"`Hello World`";

            for (int i = 0; i < realResult.Length; i++)
            {
                ConverterMDtoHTML.CheckMono(ref realResult, i);
            }

            if (realResult == expectedResult)
            {
                Console.Write("MonospacedTest: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succeed");
                Console.ResetColor();
            }
            else
            {
                Console.Write("MonospacedTest: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Whats wrong: ");
                Console.ResetColor();
                Console.WriteLine(realResult + " != " + expectedResult + "\n");
                IsPassed = false;
            }
        }

        public static void PreformatedTest(ref bool IsPassed)
        {
            string expectedResult = @"<pre>Hello World</pre>";
            string realResult = @"```Hello World```";

            for (int i = 0; i < realResult.Length; i++)
            {
                ConverterMDtoHTML.CheckPref(ref realResult, ref i);
            }

            if (realResult == expectedResult)
            {
                Console.Write("PreformatedTest: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succeed");
                Console.ResetColor();
            }
            else
            {
                Console.Write("PreformatedTest: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Whats wrong: ");
                Console.ResetColor();
                Console.WriteLine(realResult + " != " + expectedResult + "\n");
                IsPassed = false;
            }
        }

        public static void ParagraphTest(ref bool IsPassed)
        {
            string expectedResult = @"<p>Hello World</p><p>Goodbye World</p>";
            string realResult = @"Hello World

Goodbye World";

            ConverterMDtoHTML.CheckParag(ref realResult);

            if (realResult == expectedResult)
            {
                Console.Write("ParagraphTest: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succeed");
                Console.ResetColor();
            }
            else
            {
                Console.Write("ParagraphTest: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Whats wrong: ");
                Console.ResetColor();
                Console.WriteLine(realResult + " != " + expectedResult + "\n");
                IsPassed = false;
            }
        }

        public static void HTMLStructureTest(ref bool IsPassed)
        {
            string expectedResult =
@"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Document</title>
</head>
<body>
Hello World
</body>
</html>";
            string realResult = @"Hello World";

            ConverterMDtoHTML.AddHTMLStructure(ref realResult);

            if (realResult == expectedResult)
            {
                Console.Write("HTMLStructureTest: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succeed");
                Console.ResetColor();
            }
            else
            {
                Console.Write("HTMLStructureTest: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Whats wrong: ");
                Console.ResetColor();
                Console.WriteLine(realResult + "\n != \n" + expectedResult + "\n");
                IsPassed = false;
            }
        }

        public static void SummaryTest(ref bool IsPassed)
        {
            string expectedResult =
@"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Document</title>
</head>
<body>
<p><b>Hello</b> <pre>_World_</pre> <tt>!</tt></p>
</body>
</html>";
            string realResult = @"**Hello** ```_World_``` `!`";

            ConverterMDtoHTML.CheckParag(ref realResult);
            ConverterMDtoHTML.ChangeText(ref realResult);
            ConverterMDtoHTML.AddHTMLStructure(ref realResult);

            if (realResult == expectedResult)
            {
                Console.Write("SummaryTest: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succeed");
                Console.ResetColor();
            }
            else
            {
                Console.Write("SummaryTest: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Whats wrong: ");
                Console.ResetColor();
                Console.WriteLine(realResult + "\n != \n" + expectedResult + "\n");
                IsPassed = false;
            }
        }
    }
}
