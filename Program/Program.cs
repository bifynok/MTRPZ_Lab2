using Program;
class MyProgram
{
    static void Main()
    {
        string text = @"";
        string path = "", name = "";
        bool flag = false;

        try
        {
            ConverterMDtoHTML.AskForFile(ref text, ref path, ref name);
            ConverterMDtoHTML.CheckParag(ref text);
            ConverterMDtoHTML.ChangeText(ref text);
            ConverterMDtoHTML.CheckIncluded(text);
            ConverterMDtoHTML.AddHTMLStructure(ref text);
            ConverterMDtoHTML.AskForOutput(ref flag);
            if (flag)
            {
                ConverterMDtoHTML.CreateHTML(text, path, name);
                Console.WriteLine("File successfuly created!");
            }
            else
            {
                Console.WriteLine(text);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex);
        }
    }
}