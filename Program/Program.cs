using Program;
class MyProgram
{
    static void Main()
    {
        string text = @"";
        string path = "", name = "";

        try
        {
            ConverterMDtoHTML.AskForFile(ref text, ref path, ref name);
            ConverterMDtoHTML.CheckParag(ref text);
            ConverterMDtoHTML.ChangeText(ref text);
            ConverterMDtoHTML.CheckIncluded(text);
            ConverterMDtoHTML.AddHTMLStructure(ref text);
            ConverterMDtoHTML.CreateHTML(text, path, name);
            Console.WriteLine("File successfuly created!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex);
        }
    }
}