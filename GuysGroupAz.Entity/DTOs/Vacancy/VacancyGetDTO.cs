using GuysGroupAz.Entity.DTOs.VacancyDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.Vacancy
{
    public class VacancyGetDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public DateTime PublishDate { get; set; }
        public List<VacancyDetailGetDTO>? VacancyDetails { get; set; }
    }
}