namespace Szerver.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string NeptunCode { get; set; } = string.Empty;
    }
}
