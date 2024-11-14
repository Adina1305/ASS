using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void AddTask(string title, DateTime dueDate, int teacherId, int subjectId)
        {
            var task = new Tasks
            {
                Title = title,
                DueDate = dueDate,
                TeacherId = teacherId,
                SubjectId = subjectId
            };
            _taskRepository.AddTask(task);
        }

        public IEnumerable<Tasks> GetTasksForStudent(int studentId)
        {
            return _taskRepository.GetTasksForStudent(studentId);
        }

        public IEnumerable<Tasks> GetTasksForTeacher(int teacherId)
        {
            return _taskRepository.GetTasksForTeacher(teacherId);
        }

        public IEnumerable<StudentTask> GetStudentTasks(int taskId)
        {
            return _taskRepository.GetStudentTasks(taskId);
        }

        public void AddFeedback(int studentTaskId, string feedback, decimal grade)
        {
            var studentTask = _taskRepository.GetStudentTask(studentTaskId);
            studentTask.Feedback = feedback;
            studentTask.Grade = grade;
            _taskRepository.SaveChanges();
        }
    }
}
