using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public interface ITaskRepository
    {
        void AddTask(Tasks task);
        IEnumerable<Tasks> GetTasksForStudent(int studentId);
        IEnumerable<Tasks> GetTasksForTeacher(int teacherId);
        IEnumerable<StudentTask> GetStudentTasks(int taskId);
        Task<IEnumerable<Tasks>> GetAllTasks();
        Task<Tasks> GetTaskById(int id);
        StudentTask GetStudentTask(int taskId);
        void SaveChanges();
    }
}
