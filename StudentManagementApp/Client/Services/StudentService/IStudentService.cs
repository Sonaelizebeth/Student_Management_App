namespace StudentManagementApp.Client.Services.StudentService;

    public interface IStudentService
    {
      //list of students that stores collection of student data
       List<Student> students {get; set;}  
       
       //retrieve list of students
       Task GetStudents();

       //retrieve a student of id
       Task<Student> GetStudentById(int id);

       //create a new student
       Task CreateStudent(Student students);

       //update the existing student 
       Task UpdateStudent(Student students);

       //delete a student of id
       Task DeleteStudent(int id);

      
    }
