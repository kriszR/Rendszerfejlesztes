using Szerver.Models.DtoFolder;
using Szerver.Models;
using AutoMapper;

namespace Szerver.Mapper
{
    public class CourseMapper : Profile
    {
        public CourseMapper()
        {
            CreateMap<Course, GetCourseDto>();
        }
    }
}
