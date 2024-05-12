using System.Text.Json.Serialization;

namespace Szerver.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
