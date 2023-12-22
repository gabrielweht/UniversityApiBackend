using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface iStudentsServices
    {

        IEnumerable<Student> GetStudentsWithCourses();
        IEnumerable<Student> GetStudentsWithNoCourses();



    }
}
