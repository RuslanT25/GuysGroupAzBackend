using GuysGroupAz.Entity.DTOs.VacancyDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.VacancyDetail
{
    public class VacancyDetailGetDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<VacancyDescriptionGetDTO>? VacancyDescriptions { get; set; }
    }
}