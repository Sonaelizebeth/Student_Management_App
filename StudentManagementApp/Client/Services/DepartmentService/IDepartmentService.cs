namespace StudentManagementApp.Client.Services.StudentService;

    public interface IDepartmentService
    {
       //list of departments that stores collection of department data
       List<Department> departments {get;set;}

       //retrieves a list of departments
       Task GetDepartments();

       //retrieves department of id
       Task<Department> GetDepartmentById(int id);

       //create a new department
       Task CreateDepartment(Department departments);
       
       //update the existing department
       Task UpdateDepartment(Department departments);

       //delete a department of id
       Task DeleteDepartment(int id);
    }
