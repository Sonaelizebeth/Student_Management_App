//Department Service
//handling communication with server side API to perform CRUD operations on Department records
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using StudentManagementApp.DataShared;
namespace StudentManagementApp.Client.Services.StudentService;

public class DepartmentService : IDepartmentService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigationManager;
    public DepartmentService(HttpClient http, NavigationManager navigationManager)
    {
        _http=http;
        _navigationManager = navigationManager;
    }
    
    //represents a list of departments
    public List<Department> departments { get; set ; }=new List<Department>();

    //to get department by id by HTTP GET request
    public async Task<Department> GetDepartmentById(int id)
    {
        var result = await _http.GetFromJsonAsync<Department>($"api/Department/{id}");
        if(result!=null)
            return result;
        throw new NotImplementedException();
    }

    //to get all departments by HTTP GET request
    public async Task GetDepartments()
    {
        var result = await _http.GetFromJsonAsync<List<Department>>("api/Department");
        if(result!=null)
           departments=result;
    }

    //used to create new department by making HTTP POST request to server
    public async Task CreateDepartment(Department departments)
    {
        var result = await _http.PostAsJsonAsync("api/Department", departments);
        await SetDepartment(result);
    }

    //used to desearialize a list of departments from HTTP response message
    private async Task SetDepartment(HttpResponseMessage result)
    {
        if(result.IsSuccessStatusCode){
            using(Stream responsestream = await result.Content.ReadAsStreamAsync()){

            
                List<Department> responseStudents = await JsonSerializer.DeserializeAsync<List<Department>>(responsestream,new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive=true
                });
                departments = responseStudents;
            }
             _navigationManager.NavigateTo("Department");
            
        }
    }

    //to update department with id by HTTP PUT request  
    public async Task UpdateDepartment(Department department)
    {
        try{
            HttpResponseMessage result = await _http.PutAsJsonAsync($"api/Department/{department.DeptId}",department);
            if(result.IsSuccessStatusCode){
                var updated = await result.Content.ReadFromJsonAsync<List<Department>>();
                departments=updated;
            }
            else{
                var errore = await result.Content.ReadAsStringAsync();
                Console.WriteLine(errore);
            }
        }
        catch(HttpRequestException e){
            Console.WriteLine(e.Message);
        }        
    }

    //to delete a department by making HTTP DELETE request to server    
    public async Task DeleteDepartment(int id)
    {
        try{
            HttpResponseMessage result = await _http.DeleteAsync($"api/Department/{id}");
             if(result.IsSuccessStatusCode){
                await SetDepartment(result);
             }
             else{
                var erroMsg= await result.Content.ReadAsStringAsync();
                Console.WriteLine(erroMsg);
             }
        }
        catch(HttpRequestException e){
            throw e;
        }    
    }
    
}
