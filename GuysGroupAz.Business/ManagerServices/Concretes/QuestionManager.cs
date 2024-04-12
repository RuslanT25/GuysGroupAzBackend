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
    public class QuestionManager : BaseManager<Question>, IQuestionService
    {
        readonly IQuestionRepository _repository;
        public QuestionManager(IQuestionRepository questionRepository) : base(questionRepository)
        {
            _repository = questionRepository;
        }
    }
}