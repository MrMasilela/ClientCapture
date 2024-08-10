using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using ClientDetails;
using ClientDetails.Models;

namespace ClientCapture.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientContext _context;

        public ClientController(ClientContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //Get Users per location
            Dictionary<string, int> usersPerLocation = GetUsersPerLocation();

            //Getting overall users
            int totalUsers = GetTotalUsers();

            //Getting clients per date
            Dictionary<DateTime, int> clientsPerDate = GetClientsCreatedPerDate();

            //Creating the view model
            ClientDetailsViewModel clientDetailsViewModel = CreateClientDetailsViewModel(usersPerLocation, totalUsers, clientsPerDate);

            return View(clientDetailsViewModel);
        }

        private static ClientDetailsViewModel CreateClientDetailsViewModel(Dictionary<string, int> usersPerLocation, int totalUsers, Dictionary<DateTime, int> clientsPerDate)
        {
            return new ClientDetailsViewModel
            {
                UsersPerLocation = usersPerLocation,
                TotalUsers = totalUsers,
                ClientsPerDate = clientsPerDate
            };
        }

        private Dictionary<DateTime, int> GetClientsCreatedPerDate()
        {
            return _context.Clients
                            .GroupBy(c => c.DateRegistered.Date)
                            .Select(g => new { Date = g.Key, Count = g.Count() })
                            .ToDictionary(g => g.Date, g => g.Count);
        }

        private int GetTotalUsers()
        {
            return _context.Clients.Select(x => x.NumberOfUsers).Sum();
        }

        private Dictionary<string, int> GetUsersPerLocation()
        {
            return _context.Clients
                            .GroupBy(u => u.Location)
                            .Select(g => new { Location = g.Key, Count = g.Sum(h => h.NumberOfUsers) })
                            .ToDictionary(g => g.Location, g => g.Count);
        }
    }
}
