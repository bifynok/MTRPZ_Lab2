﻿namespace Program
{
    class ConverterMDtoHTML
    {
        public static void AskForFile(ref string text, ref string path, ref string name)
        {
            Console.WriteLine("Enter the path to the text file:\nExample: \"C:\\Documents\\Super Secret\\file.md\"");
            string filePath = Console.ReadLine();
            if (Path.GetExtension(filePath) == ".md")
            {
                if (File.Exists(filePath))
                {
                    text = File.ReadAllText(filePath);
                    path = Path.GetDirectoryName(filePath) + "\\";
                    name = Path.GetFileNameWithoutExtension(filePath);
                }
                else
                {
                    Console.WriteLine("File does not exist. Please try again.");
                    AskForFile(ref text, ref path, ref name);
                }
            }
            else
            {
                Console.WriteLine("The extention must be .md. Please try again.");
                AskForFile(ref text, ref path, ref name);
            }
        }

        public static void ChangeText(ref string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                CheckItalic(ref text, i);
                CheckBold(ref text, i);
                CheckPref(ref text, ref i);
                CheckMono(ref text, i);
            }
        }

        public static void CheckItalic(ref string text, int i)
        {
            if (text[i] == '_')
            {
                if (i == 0 || (i > 0 && !char.IsLetterOrDigit(text[i - 1])))
                {
                    if (i < text.Length - 1)
                    {
                        if (char.IsLetterOrDigit(text[i + 1]))
                        {
                            text = text.Remove(i, 1);
                            text = text.Insert(i, "<i>");
                            CloseItalic(ref text, i);
                        }
                        else if (char.IsPunctuation(text[i + 1]) || text[i + 1] == '`')
                        {
                            text = text.Remove(i, 1);
                            text = text.Insert(i, "<i>");
                            CloseItalic(ref text, i);
                        }
                    }
                }
            }
        }

        static void CloseItalic(ref string text, int i)
        {
            for (int j = i + 1; j < text.Length; j++)
            {
                if (text[j] == '_')
                {
                    if (j == text.Length - 1 || (j < text.Length - 1 && !char.IsLetterOrDigit(text[j + 1])))
                    {
                        if (j > 0)
                        {
                            if (char.IsLetterOrDigit(text[j - 1]))
                            {
                                text = text.Remove(j, 1);
                                text = text.Insert(j, "</i>");
                                break;
                            }
                            else if (char.IsPunctuation(text[j - 1]) || text[j - 1] == '`' || text[j - 1] == '>')
                            {
                                text = text.Remove(j, 1);
                                text = text.Insert(j, "</i>");
                                break;
                            }
                        }
                    }
                }
                else if (j == text.Length - 1)
                {
                    throw new Exception("Unclosed Punctuation");
                }
            }
        }

        public static void CheckBold(ref string text, int i)
        {
            if (text[i] == '*')
            {
                if (i < text.Length - 2 && text[i + 1] == '*')
                {
                    if (char.IsLetterOrDigit(text[i + 2]))
                    {
                        text = text.Remove(i, 2);
                        text = text.Insert(i, "<b>");
                        CloseBold(ref text, i);
                    }
                    else if (char.IsPunctuation(text[i + 2]) || text[i + 2] == '`')
                    {
                        text = text.Remove(i, 2);
                        text = text.Insert(i, "<b>");
                        CloseBold(ref text, i);
                    }
                }
            }
        }

        static void CloseBold(ref string text, int i)
        {
            for (int j = i + 1; j < text.Length; j++)
            {
                if (text[j] == '*')
                {
                    if (j > 1 && text[j - 1] == '*')
                    {
                        if (char.IsLetterOrDigit(text[j - 2]))
                        {
                            text = text.Remove(j - 1, 2);
                            text = text.Insert(j - 1, "</b>");
                            break;
                        }
                        else if (char.IsPunctuation(text[j - 2]) || text[j - 2] == '`' || text[j - 2] == '>')
                        {
                            text = text.Remove(j - 1, 2);
                            text = text.Insert(j - 1, "</b>");
                            break;
                        }
                    }
                }
                else if (j == text.Length - 1)
                {
                    throw new Exception("Unclosed Punctuation");
                }
            }
        }

        public static void CheckMono(ref string text, int i)
        {
            if (text[i] == '`')
            {
                if (i < text.Length - 1)
                {
                    if (char.IsLetterOrDigit(text[i + 1]))
                    {
                        text = text.Remove(i, 1);
                        text = text.Insert(i, "<tt>");
                        CloseMono(ref text, i);
                    }
                    else if (char.IsPunctuation(text[i + 1]) || text[i + 1] == '`')
                    {
                        text = text.Remove(i, 1);
                        text = text.Insert(i, "<tt>");
                        CloseMono(ref text, i);
                    }
                }
            }
        }

        static void CloseMono(ref string text, int i)
        {
            for (int j = i + 1; j < text.Length; j++)
            {
                if (text[j] == '`')
                {
                    if (j > 0)
                    {
                        if (char.IsLetterOrDigit(text[j - 1]))
                        {
                            text = text.Remove(j, 1);
                            text = text.Insert(j, "</tt>");
                            break;
                        }
                        else if (char.IsPunctuation(text[j - 1]) || text[j - 1] == '`' || text[j - 1] == '>')
                        {
                            text = text.Remove(j, 1);
                            text = text.Insert(j, "</tt>");
                            break;
                        }
                    }
                }
                else if (j == text.Length - 1)
                {
                    throw new Exception("Unclosed Punctuation");
                }
            }
        }

        public static void CheckPref(ref string text, ref int i)
        {
            if (text[i] == '`')
            {
                if (i < text.Length - 3 && text[i + 1] == '`' && text[i + 2] == '`')
                {
                    text = text.Remove(i, 3);
                    text = text.Insert(i, "<pre>");
                    ClosePref(ref text, ref i);
                }
            }
        }

        static void ClosePref(ref string text, ref int i)
        {
            for (int j = i + 1; j < text.Length; j++)
            {
                if (text[j] == '`')
                {
                    if (j > 2 && text[j - 1] == '`' && text[j - 2] == '`')
                    {
                        text = text.Remove(j - 2, 3);
                        text = text.Insert(j - 2, "</pre>");
                        i = j;
                        break;
                    }
                }
                else if (j == text.Length - 1)
                {
                    throw new Exception("Unclosed Punctuation");
                }
            }
        }

        public static void CheckParag(ref string text)
        {
            text = "<p>" + text;
            CloseParag(ref text, 0);
        }

        static void CloseParag(ref string text, int i)
        {
            for (int j = i; j < text.Length; j++)
            {
                if (text[j] == '\n')
                {
                    if (j < text.Length - 3 && text[j + 2] == '\n')
                    {
                        text = text.Remove(j - 1, 4);
                        text = text.Insert(j - 1, "</p><p>");
                        CloseParag(ref text, j);
                        break;
                    }
                    else if (j == text.Length - 3 && text[j + 2] == '\n')
                    {
                        text = text.Remove(j - 1, 4);
                        text = text + "</p>";
                        break;
                    }
                    else if (j == text.Length - 1)
                    {
                        text = text.Remove(j - 1, 2);
                        text = text + "</p>";
                        break;
                    }
                }
                else if (j == text.Length - 1)
                {
                    text = text + "</p>";
                    break;
                }
            }
        }

        public static void CheckIncluded(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (i < text.Length - 2 && text.Substring(i, 3) == "<i>")
                {
                    CheckIncluded_I(text, i);
                }
                else if (i < text.Length - 2 && text.Substring(i, 3) == "<b>")
                {
                    CheckIncluded_B(text, i);
                }
                else if (i < text.Length - 3 && text.Substring(i, 4) == "<tt>")
                {
                    CheckIncluded_TT(text, i);
                }
            }
        }

        static void CheckIncluded_I(string text, int i)
        {
            for (int j = i + 2; j < text.Length; j++)
            {
                if (j < text.Length - 3 && text.Substring(j, 4) == "</i>")
                {
                    break;
                }
                else if (j < text.Length - 2 && text.Substring(j, 3) == "<b>")
                {
                    throw new Exception("Included Punctuation");
                }
                else if (j < text.Length - 3 && text.Substring(j, 4) == "<tt>")
                {
                    throw new Exception("Included Punctuation");
                }
            }
        }

        static void CheckIncluded_B(string text, int i)
        {
            for (int j = i + 2; j < text.Length; j++)
            {
                if (j < text.Length - 3 && text.Substring(j, 4) == "</b>")
                {
                    break;
                }
                else if (j < text.Length - 2 && text.Substring(j, 3) == "<i>")
                {
                    throw new Exception("Included Punctuation");
                }
                else if (j < text.Length - 3 && text.Substring(j, 4) == "<tt>")
                {
                    throw new Exception("Included Punctuation");
                }
            }
        }

        static void CheckIncluded_TT(string text, int i)
        {
            for (int j = i + 2; j < text.Length; j++)
            {
                if (j < text.Length - 4 && text.Substring(j, 5) == "</tt>")
                {
                    break;
                }
                else if (j < text.Length - 2 && text.Substring(j, 3) == "<b>")
                {
                    throw new Exception("Included Punctuation");
                }
                else if (j < text.Length - 4 && text.Substring(j, 3) == "<i>")
                {
                    throw new Exception("Included Punctuation");
                }
            }
        }

        public static void CreateHTML(string text, string path, string name)
        {
            string filePath = path + "\\" + name + ".html";
            File.WriteAllText(filePath, text);
        }

        public static void AddHTMLStructure(ref string text)
        {
            text =
    @"<!DOCTYPE html>
    <html lang=""en"">
    <head>
        <meta charset=""UTF-8"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
        <title>Document</title>
    </head>
    <body>
    " + text + @"
    </body>
    </html>";
        }   
    }
}
