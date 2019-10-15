using System.Collections.Generic;
using SchoolApp.Models;

namespace SchoolApp.Services
{
    public interface IServicioDeGeneracionDeCurso
    {
        Course DoGenerateCourse(Teacher teacher, Subject subject, StudyPlan studyPlan, IEnumerable<Student> students);
    }
}