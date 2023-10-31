using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentManagementApp.DataShared;

public class Department
{
        [Key]
        [Required(ErrorMessage ="Dept Id is required")]
        public int DeptId{get; set;}
        [Required(ErrorMessage ="Department name is required")]
        public string DeptName{get; set;}    
}
