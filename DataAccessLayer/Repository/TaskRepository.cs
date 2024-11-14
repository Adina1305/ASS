using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddTask(Tasks task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public IEnumerable<Tasks> GetTasksForStudent(int studentId)
        {
            return _context.Tasks.Where(t => t.StudentTask.Any(st => st.StudentId == studentId)).ToList();
        }

        public IEnumerable<Tasks> GetTasksForTeacher(int teacherId)
        {
            return _context.Tasks.Where(t => t.TeacherId == teacherId).ToList();
        }

        public IEnumerable<StudentTask> GetStudentTasks(int taskId)
        {
            return _context.StudentTask.Where(st => st.TasksId == taskId).ToList();
        }

        public async Task<IEnumerable<Tasks>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Tasks> GetTaskById(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }
        public StudentTask GetStudentTask(int taskId)
        {
            return _context.StudentTask.FirstOrDefault(st => st.TasksId == taskId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
