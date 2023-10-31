//Student Controller
//handles CRUD operations for Student
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementApp.DataShared;
using StudentManagementApp.Server.Context;
namespace StudentManagementApp.Server.Controllers;

//specifies base route for all actions
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
   private readonly ApplicationDbcontext _context;
   public StudentController(ApplicationDbcontext context){
        _context =context;
   }

    //To get list of all Students from DB
    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetStudents(){
        var students = await _context.Studentwasm.Include(s=>s.Department).ToListAsync();
        return Ok(students);
    }

    //To get student with Id
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudentById(int id){
        var student = await _context.Studentwasm.Include(s=>s.Department).FirstOrDefaultAsync(s=>s.Id==id);
        if(student==null){
            return NotFound("Sorry, no Department");
        }
        return Ok(student);
    }

    //To create new student
    [HttpPost]
    public async Task<ActionResult<List<Student>>> CreateStudent([FromBody] Student student){
        if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }
        try{
            _context.Studentwasm.Add(student);
            await _context.SaveChangesAsync();
            return Ok(await GetDbStudents());
        }
        catch(Exception e){
            return StatusCode(500,"An error"+e.Message);

        }
       
    }

    //To update a student with Id
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Student>>> UpdateStudent(Student student, int id){
       
        var dbstudent = await  _context.Studentwasm.FindAsync(id);
        if(dbstudent==null)
            return NotFound("Sorry, no student ");
        dbstudent.Name = student.Name;
        dbstudent.FirstMark=student.FirstMark;
        dbstudent.SecondMark=student.SecondMark;
        dbstudent.TotalMark=student.TotalMark;
        //dbstudent.DeptId=student.DeptId;
        dbstudent.Department=student.Department;
        await _context.SaveChangesAsync();
        return Ok(await GetDbStudents());
    }

    //To delete student with Id
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Student>>> DeleteStudent(int id){     
        var dbstudent = await  _context.Studentwasm.FindAsync(id);
        if(dbstudent==null)
            return NotFound("Sorry, no student ");
        _context.Studentwasm.Remove(dbstudent);
        await _context.SaveChangesAsync();
        return Ok(await GetDbStudents());
    }

    //private helper method used internally to obtain students from db
    private async Task<List<Student>> GetDbStudents(){
        return await _context.Studentwasm.Include(s=>s.Department).ToListAsync();
    }
}
