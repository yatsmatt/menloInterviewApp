using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks.Dataflow;

namespace formatApi
{
    public class formatFactory
    {
        public static abstractFormat getFormat(string type)
        {
            if (type.Equals(".txt", StringComparison.OrdinalIgnoreCase))
            {
                return new ABC();
            }
            else if (type.Equals(".YXZ", StringComparison.OrdinalIgnoreCase))
            {
                return new ABC();
            }
            else
            {
                return null;
            }

        }
    }
}