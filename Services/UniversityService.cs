using Microsoft.EntityFrameworkCore;
using UniClass.Data;
using UniClass.Models;
namespace UniClass.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly AppDbContext _db;

        public UniversityService(AppDbContext db)
        {
            _db = db;
        }

        #region Students

        public async Task<List<Student>> GetStudentsAsync()
        {
            try
            {
                return await _db.Students.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Student> GetStudentAsync(Guid id, bool includeMajors)
        {
            try
            {
                if (includeMajors) // majors should be included
                {
                    return await _db.Students.Include(m => m.Major)
                        .FirstOrDefaultAsync(i => i.Id == id);
                }

                // Majors should be excluded
                return await _db.Students.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Student> AddStudentAsync(Student Student)
        {
            try
            {
                await _db.Students.AddAsync(Student);
                await _db.SaveChangesAsync();
                return await _db.Students.FindAsync(Student.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Student> UpdateStudentAsync(Student Student)
        {
            try
            {
                _db.Entry(Student).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return Student;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteStudentAsync(Student Student)
        {
            try
            {
                var dbStudent = await _db.Students.FindAsync(Student.Id);

                if (dbStudent == null)
                {
                    return (false, "Student could not be found");
                }

                _db.Students.Remove(Student);
                await _db.SaveChangesAsync();

                return (true, "Student got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Students

        #region Majors

        public async Task<List<Major>> GetMajorsAsync()
        {
            try
            {
                return await _db.Majors.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Major> GetMajorAsync(Guid id)
        {
            try
            {
                return await _db.Majors.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Major> AddMajorAsync(Major Major)
        {
            try
            {
                await _db.Majors.AddAsync(Major);
                await _db.SaveChangesAsync();
                return await _db.Majors.FindAsync(Major.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Major> UpdateMajorAsync(Major Major)
        {
            try
            {
                _db.Entry(Major).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return Major;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteMajorAsync(Major Major)
        {
            try
            {
                var dbMajor = await _db.Majors.FindAsync(Major.Id);

                if (dbMajor == null)
                {
                    return (false, "Major could not be found.");
                }

                _db.Majors.Remove(Major);
                await _db.SaveChangesAsync();

                return (true, "Major got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Majors
    }
}
