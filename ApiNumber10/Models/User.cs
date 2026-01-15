namespace ApiNumber10.Models
{
    public class User
    {
        public Guid id { get; set; }
        public required string name { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
    }
}
