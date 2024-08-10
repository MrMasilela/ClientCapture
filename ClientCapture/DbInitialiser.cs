using DataAccess.Context;
using DataAccess.Models;

namespace ClientCapture
{
    public static class DbInitialiser
    {   
        public static void Initialise(ClientContext context)
        {
            context.Database.EnsureCreated();

            //Look for any clients.
            if(context.Clients.Any())
            {
                return; //DB has been seeded
            }

            var clients = new Client[]
            {
                new Client{Name = "John",DateRegistered = new DateTime(2024,06,07),Location = "Cape Town", NumberOfUsers = 2},
                new Client{Name = "Musa",DateRegistered = new DateTime(2024,07,07),Location = "Cape Town", NumberOfUsers = 4},
                new Client{Name = "Kerin",DateRegistered = new DateTime(2024,06,07),Location = "Johannesburg", NumberOfUsers = 1},
                new Client{Name = "Jake",DateRegistered = new DateTime(2024,08,15),Location = "Bloemfontein", NumberOfUsers = 7},
                new Client{Name = "Patrick",DateRegistered = new DateTime(2024,06,10),Location = "Johannesburg", NumberOfUsers = 5}

            };

            foreach (var client in clients)
            {
                context.Clients.Add(client);
            }
            context.SaveChanges();
        }
    }
}
