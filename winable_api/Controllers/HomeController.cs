using Microsoft.AspNetCore.Mvc;
using winable_api.DataDB;
using winable_api.Repository;

namespace winable_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IStudent _studentRepository;

        public HomeController(IStudent sturepo) {
            _studentRepository= sturepo;
        }

        [HttpGet]

        public List<Student> getAllStudents()
        {
            return _studentRepository.getAllStudents();
        }

        [HttpGet("{id}")]
        public Student getById(int id)
        {
            return _studentRepository.getStudentById(id);
        }

        [HttpPost("addstudent")]
        public Student addStudents(Student student)
        {
            return _studentRepository.addStudent(student);
        }

        [HttpPost("addcollege")]
        public College addCollege(College college)
        {
            return _studentRepository.addCollege(college);
        }

        [HttpGet("getCollegeList")]
        public List<College> getAllColleges()
        {
            return _studentRepository.getAllColleges();
        }

        [HttpPost("deleteStudent")]
        public Student deleteStudents(int id)
        {
            return _studentRepository.deleteStudent(id);
        }

        [HttpPut("updateStudent")]
        public Student updateStudents(Student student)
        {
            return _studentRepository.updateStudent(student);
        }
    }
}
