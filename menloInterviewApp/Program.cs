using System;
using System.Text;
using System.Text.RegularExpressions;

namespace menloInterviewApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\yatsi\Desktop\c#\menloInterviewApp\menloInterviewApp\test.txt";
            readFile();
        }
        //main option2:use File c# (working) heavyer
        static void readFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("worng path!");
            }
            try
            {
                string[] lines = File.ReadAllLines(path);
                int numberOfBytes = 3;
                string checkStart = @"123";
                string checkEnd = @"789";
                string replace = "A255C";
                string correct = @"A[1-9]C";
                //start
                lines[0] = sanitizesEdges(lines[0], numberOfBytes, checkStart, 0);
                //mid
                for (int i = 1; i < lines.Length - 1; i++)
                {
                    string newLine = sanitizesLine(lines[i].Trim(), numberOfBytes, replace, correct);
                    if (!lines[i].Trim().Equals(newLine))
                    {
                        lines[i] = newLine;
                    }
                }
                //end
                string lastLine = lines[lines.Length - 1];
                lines[lines.Length - 1] = sanitizesEdges(lastLine, numberOfBytes, checkEnd, lastLine.Length - numberOfBytes);
                File.WriteAllLines(path, lines);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        static string sanitizesLine(string line, int numberOfBytes, string replace, string correct)
        {
            StringBuilder sanitizesLine = new StringBuilder();


            for (int i = 0; i < line.Length; i = i + numberOfBytes)
            {
                if (Regex.IsMatch(line.Substring(i, numberOfBytes), correct))
                {
                    sanitizesLine.Append(line.Substring(i, numberOfBytes));
                }
                else
                {
                    sanitizesLine.Append(replace);
                }
            }
            return sanitizesLine.ToString();
        }
        static string sanitizesEdges(string line, int numberOfBytes, string correct, int index)
        {
            StringBuilder sanitizesTxt = new StringBuilder();
            string edge = line.Substring(index, numberOfBytes);
            if (Regex.IsMatch(edge, correct))
            {
                sanitizesTxt.Append(edge);
            }
            return sanitizesTxt.ToString();
        }
        //main option1: string bullder approch need to be tested (new file)
        static void readFile()
        {
            string path = @"C:\Users\yatsi\Desktop\c#\menloInterviewApp\menloInterviewApp\test.txt";
            string tmp = "temp.txt";
            int numberOfBytes = 3;
            string replace = "A255C";
            string correct = @"A[1-9]C";
            string checkStart = @"123";
            string checkEnd = @"789";
            try
            {
                using (var reader = new StreamReader(path))
                using (var writer = new StreamWriter(tmp))
                {
                    string? line;
                    bool isFirstLine = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isFirstLine)
                        {
                            if (Regex.IsMatch(line.Trim(), checkStart))
                            {
                                writer.WriteLine(line);
                            }
                            isFirstLine = false;
                        }
                        else if (reader.Peek() == -1)
                        {
                            if (Regex.IsMatch(line.Trim(), checkEnd))
                            {
                                writer.WriteLine(line);
                            }
                        }
                        else
                        {
                            writer.WriteLine(sanitizesLine(line, numberOfBytes, replace, correct));
                        }
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}