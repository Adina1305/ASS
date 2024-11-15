using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public interface ITaskRepository
    {
        void Add(Tasks task);
    }

}