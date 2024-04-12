﻿using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Concretes
{
    public class VacancyDescriptionManager : BaseManager<VacancyDescription>, IVacancyDescriptionService
    {
        readonly IVacancyDescriptionRepository _repository;
        public VacancyDescriptionManager(IVacancyDescriptionRepository vacancyDescriptionRepository) : base(vacancyDescriptionRepository)
        {
            _repository = vacancyDescriptionRepository;
        }
    }
}