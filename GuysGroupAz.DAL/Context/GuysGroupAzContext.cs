using GuysGroupAz.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.DAL.Context
{
    public class GuysGroupAzContext : DbContext
    {
        public GuysGroupAzContext(DbContextOptions<GuysGroupAzContext> options) : base(options)
        {

        }

        public DbSet<News> News { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Subscribe> Subscribes {  get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<OtherInfoDescription> OtherInfoDescriptions { get; set; }
        public DbSet<OtherInfo> OtherInfos { get; set; }
        public DbSet<GeneralInfo> GeneralInfos {  get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<VacancyDescription> VacancyDescriptions { get; set; }
        public DbSet<VacancyDetail> VacancyDetails { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
