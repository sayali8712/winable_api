using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using winable_api.DataDB;

namespace winable_api.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly CollegeContext _collegeContext;
        public StudentRepository(CollegeContext collegeContext) { 
        
            _collegeContext = collegeContext;
        }

        public Student addStudent(Student student)
        {
            _collegeContext.Students.Add(student);
            _collegeContext.SaveChanges();
            return student;
        }

        public College addCollege(College college)
        {
            _collegeContext.Colleges.Add(college);
            _collegeContext.SaveChanges();
            return college;
        }

        public List<Student> getAllStudents()
        {
            return _collegeContext.Students.ToList();
        }

        public List<College> getAllColleges()
        {
            return _collegeContext.Colleges.ToList();
        }

        public Student getStudentById(int id)
        {
            var student=_collegeContext.Students.Where(s=>s.Id==id).FirstOrDefault();
            
            return student;
        }

        public Student deleteStudent(int id)
        {
            var deletedrecord = _collegeContext.Students.Where(s => s.Id == id).FirstOrDefault();
            _collegeContext.Students.Remove(deletedrecord);
            _collegeContext.SaveChanges();
            return deletedrecord;
        }

        public Student updateStudent(Student student)
        {
            _collegeContext.Students.Update(student);
            _collegeContext.SaveChanges();
            var student1 = _collegeContext.Students.Where(s => s.Id == student.Id).FirstOrDefault();
            return student1;
        }
    }
}
