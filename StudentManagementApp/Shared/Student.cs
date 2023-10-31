using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentManagementApp.DataShared;

public class Student
{
        //specify the primary key
        [Key] 
        [Required(ErrorMessage ="Id is required")]
        public int Id{get; set;}
        [Required(ErrorMessage ="Name is required")]
        public string Name{get; set;}
        [Required(ErrorMessage ="Mark is required")]
        public int FirstMark{get; set;}
        [Required(ErrorMessage ="Mark is required")]
        public int SecondMark{get; set;}
        [Required(ErrorMessage ="Mark is required")]
        public int TotalMark{get; set;}
        // [Required(ErrorMessage ="Department is required")]
        public int DeptId{get; set;}
        // added foreign key
        [ForeignKey("DeptId")]
        //Department property is nullable 
        public Department? Department{get; set;}   

}

