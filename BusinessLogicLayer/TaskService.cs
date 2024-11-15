using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using DataAccessLayer.Repository;

namespace BusinessLogicLayer
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Add(Tasks task)
        {
            _taskRepository.Add(task); 
        }
    }

}