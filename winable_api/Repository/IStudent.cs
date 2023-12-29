using winable_api.DataDB;

namespace winable_api.Repository
{
    public interface IStudent
    {
        List<Student> getAllStudents();
        List<College> getAllColleges();
        Student getStudentById(int id);
        Student addStudent(Student student);
        College addCollege(College college);
        Student deleteStudent(int id);
        Student updateStudent(Student student);
    }
}
