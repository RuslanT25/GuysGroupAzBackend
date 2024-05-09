using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Models
{
    public class Vacancy : BaseEntity
    {
        public string Title {  get; set; }
        public string Email { get; set; }
        public virtual List<VacancyDetail>? VacancyDetails { get; set; }
        public DateTime PublishDate { get; set; }
    }
}