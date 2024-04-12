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
    public class SendMessageManager : BaseManager<SendMessage>, ISendMessageService
    {
        readonly ISendMessageRepository _repository;
        public SendMessageManager(ISendMessageRepository sendMessage) : base(sendMessage)
        {
            _repository = sendMessage;
        }
    }
}
