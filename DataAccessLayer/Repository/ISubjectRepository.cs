using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetSubjectsForTeacherAsync(int teacherId);
    }

}
