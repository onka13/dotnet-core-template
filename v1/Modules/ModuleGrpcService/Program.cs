using ModuleCommon.API;

namespace ModuleGrpcService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var startup = new Startup();
            ProgramCommon.Main(args, startup);
        }
    }
}
