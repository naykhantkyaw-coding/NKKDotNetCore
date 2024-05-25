using NKKDotNetCore.ConsoleAppRestClient;

RestClientExample restClientExample = new RestClientExample();
Console.WriteLine("RestClient");
await restClientExample.Run();
Console.ReadKey();
