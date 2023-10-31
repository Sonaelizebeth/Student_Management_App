//Student Service
//handling communication with server side API to perform CRUD operations on Student records
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using StudentManagementApp.DataShared;
namespace StudentManagementApp.Client.Services.StudentService;

public class StudentService : IStudentService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigationManager;
    public StudentService(HttpClient http, NavigationManager navigationManager)
    {
        _http=http;
        _navigationManager = navigationManager;
    }

    //represents a list of students
    public List<Student> students { get; set; } = new List<Student>();
    
    //used to create new student by making HTTP POST request to server
     public async Task CreateStudent(Student students)
    {       
        var result = await _http.PostAsJsonAsync("api/student", students);       
        if(result.IsSuccessStatusCode){
             await GetStudents();
            _navigationManager.NavigateTo("Student");
        }
        else{
            var e =await result.Content.ReadAsStringAsync();
            Console.WriteLine(e);
        }       
    }
    
    //used to deserialize a list of students from HTTP response message
    private async Task SetStudent(HttpResponseMessage result)
    {
        if(result.IsSuccessStatusCode){
            using(Stream responsestream = await result.Content.ReadAsStreamAsync()){            
                List<Student> responseStudents = await JsonSerializer.DeserializeAsync<List<Student>>(responsestream,new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive=true
                });
                students = responseStudents;
            }
             _navigationManager.NavigateTo("Student");           
        }
    }

    //to delete a student by making HTTP DELETE request to server
    public async Task DeleteStudent(int id)
    {
        try{
            HttpResponseMessage response = await _http.DeleteAsync($"api/student/{id}");
             if(response.IsSuccessStatusCode){
                await SetStudent(response);
             }
             else{
                var errorMsg= await response.Content.ReadAsStringAsync();
                Console.WriteLine(errorMsg);
             }
        }
        catch(HttpRequestException e){
            throw e;
        }    
    }

    //to get student by id by HTTP GET request
    public async Task<Student> GetStudentById(int id)
    {       
        var result = await _http.GetFromJsonAsync<Student>($"api/Student/{id}");
        if(result!=null)
            return result;
        throw new Exception("Student not found");
    }

    //to get all students by HTTP GET request
    public async Task GetStudents()
    {
        var result = await _http.GetFromJsonAsync<List<Student>>("api/Student");
        if(result!=null)
            students=result;
    }

    //to update student with id by HTTP PUT request
    public async Task UpdateStudent(Student student)
    {
        try{
            HttpResponseMessage res = await _http.PutAsJsonAsync($"api/Student/{student.Id}",student);
            if(res.IsSuccessStatusCode){
                var updatedStudent = await res.Content.ReadFromJsonAsync<List<Student>>();
                students=updatedStudent;
            }
            else{
                var errorMessage = await res.Content.ReadAsStringAsync();
                Console.WriteLine(errorMessage);
            }
        }
        catch(HttpRequestException e){
            Console.WriteLine(e.Message);
        } 
    }
   
}
