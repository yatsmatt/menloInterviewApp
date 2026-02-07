using System;
using System.Text;
using System.Text.RegularExpressions;

namespace formatApi
{
    public class ABC : abstractFormat
    {

        public ABC(string fileLocation) : base()
        {
            this.fileLocation = fileLocation;
            this.numberOfBytes = 3;
            this.header = "123";
            this.footer = "789";
            this.replaceReg = "A255C";
            this.correctReg = "A[1-9]C";
        }
        public ABC(string fileLocation, int numberOfBytes, string header, string footer, string replaceReg, string correctReg) : base()
        {
            this.fileLocation = fileLocation;
            this.numberOfBytes = numberOfBytes;
            this.header = header;
            this.footer = footer;
            this.replaceReg = replaceReg;
            this.correctReg = correctReg;
        }

        public override string sanitizesLine(string line)
        {
            StringBuilder sanitizesLine = new StringBuilder();

            for (int i = 0; i < line.Length; i = i + this.numberOfBytes)
            {
                if (Regex.IsMatch(line.Substring(i, this.numberOfBytes), this.correctReg))
                {
                    sanitizesLine.Append(line.Substring(i, this.numberOfBytes));
                }
                else
                {
                    sanitizesLine.Append(this.replaceReg);
                }
            }
            return sanitizesLine.ToString();
        }

        public override void sanitizeFile()
        {
            // string path = @"C:\Users\yatsi\Desktop\c#\menloInterviewApp\menloInterviewApp\test.txt";
            string tmp = "temp.txt";

            try
            {
                using (var reader = new StreamReader(this.fileLocation))
                using (var writer = new StreamWriter(tmp))
                {
                    string? line;
                    bool isFirstLine = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isFirstLine)
                        {
                            if (Regex.IsMatch(line.Trim(), this.header))
                            {
                                writer.WriteLine(line);
                            }
                            isFirstLine = false;
                        }
                        else if (reader.Peek() == -1)
                        {
                            if (Regex.IsMatch(line.Trim(), this.footer))
                            {
                                writer.WriteLine(line);
                            }
                        }
                        else
                        {
                            writer.WriteLine(sanitizesLine(line));
                        }
                    }
                }
                File.Delete(this.fileLocation);
                File.Move(tmp, this.fileLocation);

            }
            catch (System.Exception e)
            {

                Console.WriteLine(e);
            }
        }
    }
}