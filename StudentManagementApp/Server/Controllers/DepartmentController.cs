//Department Controller
//handles CRUD operations for Department
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementApp.DataShared;
using StudentManagementApp.Server.Context;
namespace StudentManagementApp.Server.Controllers;

//specifies base route for all actions
[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
   private readonly ApplicationDbcontext _context;
   public DepartmentController(ApplicationDbcontext context){
        _context =context;
   }
     
    //To get list of all departments from DB
    [HttpGet]
    public async Task<ActionResult<List<Department>>> GetDepartments(){
        var departments = await _context.SonaDepartmentwasmTask2.ToListAsync();
        return Ok(departments);
    }
    
    //To get department by DeptId
    [HttpGet("{id}")]
    public async Task<ActionResult<Department>> GetDepartmentById(int id){
        var department = await _context.SonaDepartmentwasmTask2.FirstOrDefaultAsync(s=>s.DeptId==id);
        if(department==null){
            return NotFound("Sorry, no student");
        }
        return Ok(department);
    }

    //To create a new Department
    [HttpPost]
    public async Task<ActionResult<List<Department>>> CreateDepartment(Department department){
        _context.SonaDepartmentwasmTask2.Add(department);
        await _context.SaveChangesAsync();
        return Ok(await GetDbDepartments());
    }

    //To update department by id
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Department>>> UpdateDepartment(Department department, int id){
       
        var dbstudent = await  _context.SonaDepartmentwasmTask2.FindAsync(id);
        if(dbstudent==null)
            return NotFound("Sorry, no student ");
       
        dbstudent.DeptName=department.DeptName;
        await _context.SaveChangesAsync();
        return Ok(await GetDbDepartments());

    }

    //To delete a department by Id
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Department>>> DeleteDepartment(int id){
       
        var department = await  _context.SonaDepartmentwasmTask2.FindAsync(id);
        if(department==null)
            return NotFound("Sorry, no Department ");
        _context.SonaDepartmentwasmTask2.Remove(department);
        await _context.SaveChangesAsync();
        return Ok(await GetDbDepartments());

    }

    //private helper method used internally to get the Departments from database
    private async Task<List<Department>> GetDbDepartments(){
        return await _context.SonaDepartmentwasmTask2.ToListAsync();
    }

}
