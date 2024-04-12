using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Concretes
{
    public class ContactManager : BaseManager<Contact>, IContactService
    {
        readonly IContactRepository _repository;
        public ContactManager(IContactRepository contactRepository) : base(contactRepository)
        {
            _repository = contactRepository;
        }
    }
}
