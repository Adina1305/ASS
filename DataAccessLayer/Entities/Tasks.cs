using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public int TeacherId { get; set; }
        public User Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ICollection<StudentTask> StudentTask { get; set; } 
    }

}
