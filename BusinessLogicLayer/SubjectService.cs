using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using System;


namespace BusinessLogicLayer
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public void AddSubject(Subject subject)
        {
            if (subject == null)
                throw new ArgumentNullException(nameof(subject));

            _subjectRepository.Add(subject);  
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _subjectRepository.GetAll(); 
        }
    }

}
