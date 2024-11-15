using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Subject subject)
        {
            try
            {
                _context.Subjects.Add(subject);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                throw;  
            }
        }


        public IEnumerable<Subject> GetAll()
        {
            return _context.Subjects.ToList();
        }

        public async Task<IEnumerable<Subject>> GetSubjectsForTeacherAsync(int teacherId)
        {
            return await _context.Subjects
                .Where(s => s.TeacherId == teacherId)
                .ToListAsync();
        }
    }


}
