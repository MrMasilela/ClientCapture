using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

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
            var clients = _context.Clients.ToList();
            return View(clients);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name,DateRegistered,Location,NumberOfUsers")] Client client)
        {
            ValidateUniqueName(client);

            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        private void ValidateUniqueName(Client client)
        {
            if (_context.Clients.Any(x => x.Name == client.Name))
            {
                ModelState.AddModelError("Name", "This name is already in use");
            }
        }
    }
}
