using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.Question
{
    public class QuestionGetDTO
    {
        public int Id { get; set; }
        public string Issue { get; set; }
        public string Answer { get; set; }
    }
}