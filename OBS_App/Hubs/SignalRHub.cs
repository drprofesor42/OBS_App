using Microsoft.AspNetCore.SignalR;
using OBS_App.Models;

namespace OBS_App.Hubs
{
    public class SignalRHub: Hub
    {
        private readonly IdentityDataContext _context;

        public SignalRHub(IdentityDataContext context)
        {
            _context = context;
        }

        public async Task SendFakulteCount()
        {

        }
    }
}
