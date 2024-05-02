using System.Text.Json.Serialization;

namespace Szerver.Models
{
    public class MyCourse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int CourseId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
    }
}
