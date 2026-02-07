using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks.Dataflow;

namespace formatApi
{
    public class FormatFactory
    {
        public static AbstractFormat getFormat(string type, string path)
        {
            if (type.Equals(".txt", StringComparison.OrdinalIgnoreCase))
            {
                return new ABC(path);
            }
            else if (type.Equals(".ABC", StringComparison.OrdinalIgnoreCase))
            {
                return new ABC(path);
            }
            else
            {
                return null;
            }

        }
    }
}