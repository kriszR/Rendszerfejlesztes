namespace Szerver.Models.DtoFolder
{
    public class EventDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateEventDto : EventDto
    {
    }

    public class GetEventDto : EventDto
    {
        public GetCourseDto Course { get; set; }
    }
}
