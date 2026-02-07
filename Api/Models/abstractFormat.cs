namespace formatApi
{
    public abstract class AbstractFormat
    {
        protected string fileLocation { get; set; } = null!;
        protected int numberOfBytes { get; set; }
        protected string header { get; set; } = null!;
        protected string footer { get; set; } = null!;
        protected string replaceReg { get; set; } = null!;
        protected string correctReg { get; set; } = null!;

        public abstract string sanitizesLine(string line);
        public abstract string sanitizeFile();


    }
}