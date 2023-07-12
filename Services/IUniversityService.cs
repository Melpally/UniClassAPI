using UniClass.Models;
namespace UniClass.Services
{
    public interface IUniversityService
    {
        //Student services - CRUD implementation for REST api
        Task<List<Student>> GetStudentsAsync(); // Select (or GET All) Students
        Task<Student> GetStudentAsync(Guid id, bool includeMajors = false); // Select by Id of a Single Student
        Task<Student> AddStudentAsync(Student student); // Create or POST New Student
        Task<Student> UpdateStudentAsync(Student student); // Update or PUT student
        Task<(bool, string)> DeleteStudentAsync(Student student); // DELETE student

        //Student majors - CRUD
        Task<List<Major>> GetMajorsAsync(); 
        Task<Major> GetMajorAsync(Guid id); 
        Task<Major> AddMajorAsync(Major Major); 
        Task<Major> UpdateMajorAsync(Major Major); 
        Task<(bool, string)> DeleteMajorAsync(Major Major);
    }
}
