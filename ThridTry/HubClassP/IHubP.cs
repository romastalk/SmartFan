using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using ThridTry.Data;

namespace ThridTry.HubClassP
{
    public interface IHubP
    {
        Task AppM(string m);
    }
   
}