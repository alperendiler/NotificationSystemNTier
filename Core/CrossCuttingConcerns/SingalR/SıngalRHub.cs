using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.SingalR
{
    public class SıngalRHub<T> : Hub
    {
        public async Task SendNotification(T message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
