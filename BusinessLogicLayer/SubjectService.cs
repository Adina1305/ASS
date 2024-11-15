using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using System;


namespace BusinessLogicLayer
{
    public class SubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<Subject>> GetSubjectsForTeacher(int teacherId)
        {
            return await _subjectRepository.GetSubjectsForTeacherAsync(teacherId);
        }
    }

}
