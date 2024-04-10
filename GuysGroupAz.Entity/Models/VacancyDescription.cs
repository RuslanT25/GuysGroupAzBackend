using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Models
{
    public class VacancyDescription : BaseEntity
    {
        public string Description { get; set; }
        public virtual VacancyDetail VacancyDetail { get; set; }
        public int VacancyDetailId { get; set; }
    }
}
