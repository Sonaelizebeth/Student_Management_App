using System.ComponentModel.DataAnnotations.Schema;
using StudentManagementApp.Client.Pages;
using StudentManagementApp.DataShared;

namespace StudentManagementApp.Server.Context;

public class ApplicationDbcontext : DbContext
{
    //using dependency injection to pass 'DbContextOptions<ApplicationDbcontext>' to base class constructor 
    // to configure the db connection
    public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options) {

     }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //specifying default schema
        modelBuilder.HasDefaultSchema("sonaelizebeth");

        //HasData to seed initial data
        modelBuilder.Entity<Department>().HasData(
            new Department {DeptId=401,DeptName = "Artificial Intelligence"},
            new Department {DeptId=402,DeptName = "Computer Science"}
        );
       
        modelBuilder.Entity<Student>().HasData(
            new Student{
                Id=101,
                Name="Arjun Mahadevan",
                FirstMark=90,
                SecondMark=91,
                TotalMark=181,
                DeptId=401,
            },
            new Student{
                Id=102,
                Name="Mathew Anil",
                FirstMark=90,
                SecondMark=91,
                TotalMark=181,
                DeptId=402,
            }

        );
    }
    
    public DbSet<Student> SonaStudentwasmTask2 {get;set;}
    public DbSet<Department> SonaDepartmentwasmTask2 {get;set;}
}
