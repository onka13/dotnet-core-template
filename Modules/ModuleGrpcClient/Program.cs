using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using ModuleGrpcService;

namespace ModuleGrpcClient
{
    class Program
    {
        static GrpcChannel channel;

        static async Task Main(string[] args)
        {
            channel = GrpcChannel.ForAddress("https://localhost:44330");

            await SayHello();
            await GetUser();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static async Task SayHello()
        {
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
        }
        
        static async Task GetUser()
        {
            var client = new UserGrpc.UserGrpcClient(channel);
            var user = await client.GetUserAsync(new GetUserRequest { Id = 1 });
            Console.WriteLine("Name: " + user.Name);
            Console.WriteLine("Email: " + user.Email);
        }
    }
}
