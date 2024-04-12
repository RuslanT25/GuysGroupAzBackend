using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Concretes
{
    public class TeacherManager : BaseManager<Teacher>, ITeacherService
    {
        readonly ITeacherRepository _repository;
        public TeacherManager(ITeacherRepository teacherRepository) : base(teacherRepository)
        {
            _repository = teacherRepository;
        }
    }
}