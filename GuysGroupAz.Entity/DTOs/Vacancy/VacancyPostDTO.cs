using GuysGroupAz.Entity.DTOs.VacancyDetail;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.Vacancy
{
    public class VacancyPostDTO
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public DateTime PublishDate { get; set; }
        public List<int>? VacancyDetailIds { get; set; }
    }
}