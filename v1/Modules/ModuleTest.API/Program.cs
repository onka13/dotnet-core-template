using ModuleCommon.API;

namespace ModuleTest.API
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var startup = new Startup();
            ProgramCommon.Main(args, startup);
        }
    }
}
