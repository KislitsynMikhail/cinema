using System.Linq;
using System.Threading.Tasks;
using Cinema.Server.Models;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace Cinema.Server.Hubs
{
    public class AppHub : Hub
    {
        public AppHub()
        {
            Hub = this;
        }

        public static AppHub Hub { get; private set; }

        public void SendFilmSessions()
        {
            using var db = new DatabaseContext();

            var filmSessions = db.FilmSessions.ToArray();

            var filmSessionsStr = JsonConvert.SerializeObject(filmSessions);

            Clients.All.SetFilmSessions(filmSessionsStr);
        }

        public override Task OnConnected()
        {
            SendFilmSessions();

            return base.OnConnected();
        }
    }
}