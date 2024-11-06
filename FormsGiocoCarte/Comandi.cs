using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
    public enum ComandiServer
    {
        EnterQueue,
        LeaveQueue,
        EnterServer,
        GetServers,
        GetPlayers,
        Help = 7,
        Disconnect = 8,
        Info = 9
    }

    public enum ComandiClient
    {
        Reconnect,
        GetMatchId,
        PartitaCreata,
        SendMatchId,
        DecideStarts,
        UpdateGame,
        Info = 9
    }

    public enum ComandiMatch
    {
        ConnectMatch,
        SendDeck,
        GetGameCount,
        SendMove,
        Info = 9
    }
}
