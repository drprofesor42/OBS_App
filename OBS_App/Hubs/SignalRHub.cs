using Microsoft.AspNetCore.SignalR;
using OBS_App.Data;
using OBS_App.Models;
using System.Security.Claims;

namespace OBS_App.Hubs
{
    public class SignalRHub : Hub<Mesajisim>
    {
        private readonly IdentityDataContext _context;
        public SignalRHub(IdentityDataContext context)
        {
            _context = context;
        }
        public async Task DuyuruBildirim(string baslik, string duyuru)
        {
            await Clients.Others.Duyuru(baslik, duyuru);

        }

        public override Task OnConnectedAsync()
        {
            var id = Context.ConnectionId;
            var email = Context.User?.FindFirst(ClaimTypes.Email)?.Value;
            _context.Baglantılar.Add(new Baglantı
            {
                connectionid = id,
                eposta= email,
            });
            _context.SaveChanges();
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var email = Context.User?.FindFirst(ClaimTypes.Email)?.Value;
            var user = _context.Baglantılar.Where(x => x.eposta == email).ToList();
            if (user.Any())
            {
                _context.RemoveRange(user);
                _context.SaveChanges();
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
