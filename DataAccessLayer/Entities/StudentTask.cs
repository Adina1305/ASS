using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class StudentTask
    {
        public int Id { get; set; }
        public int TasksId { get; set; }
        public Tasks Tasks { get; set; }
        public int StudentId { get; set; }
        public User Student { get; set; }
        public string FilePath { get; set; }
        public bool IsCompleted { get; set; }
        public decimal? Grade { get; set; }
    }
}
