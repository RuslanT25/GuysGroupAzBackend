using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Models
{
    public class VacancyDetail : BaseEntity
    {
        public string Title { get; set; }
        public virtual List<VacancyDescription> VacancyDescriptions { get; set; }
        public virtual Vacancy Vacancy { get; set; }
        public int VacancyId { get; set; }
    }
}
