using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.VacancyDetail
{
    public class VacancyDetailPostDTO
    {
        public string Title { get; set; }
        public List<int>? VacancyDescriptionIds { get; set; }
    }
}