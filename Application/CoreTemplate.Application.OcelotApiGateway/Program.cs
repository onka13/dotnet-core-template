using ModuleCommon.API;
using System.Net;

namespace CoreTemplate.Application.OcelotApiGateway
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
            //ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            var startup = new Startup();
            ProgramCommon.Main(args, startup);
        }
    }
}
