namespace Szerver.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int DegreeId { get; set; }
        //public Degrees Degree { get; set; }
       
    }
}
