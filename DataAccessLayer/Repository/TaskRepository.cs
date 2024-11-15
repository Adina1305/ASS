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

        public void Add(Tasks task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

    }
}