namespace formatApi
{
    public abstract class abstractFormat
    {
        protected string fileLocation { get; set; }
        protected int numberOfBytes { get; set; }
        protected string header { get; set; }
        protected string footer { get; set; }
        protected string replaceReg { get; set; }
        protected string correctReg { get; set; }

        public abstract string sanitizesLine(string line);
        public abstract void sanitizeFile();


    }
}