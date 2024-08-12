namespace ClientDetails.Models
{
    public class ClientDetailsViewModel
    {
        public Dictionary<string, int> UsersPerLocation { get; set; }
        public int TotalUsers { get; set; }
        public Dictionary<DateTime, int> ClientsPerDate { get; set; }

    }

}
