namespace Szerver.Models
{
    public class Events
    {
        public int Id { get; set; }
        public int Course_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
