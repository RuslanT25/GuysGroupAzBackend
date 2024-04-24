using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.Entity.DTOs.SendMessage;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        readonly ISendMessageService _sendMessageService;
        readonly IMapper _mapper;
        readonly SendMessageValidation _sendMessageValidation;
        public SendMessageController(ISendMessageService sendMessageService, IMapper mapper, SendMessageValidation validationRules)
        {
            _sendMessageService = sendMessageService;
            _mapper = mapper;
            _sendMessageValidation = validationRules;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _sendMessageService.GetAllAsync();
            var sendMessages = _mapper.Map<List<SendMessageGetDTO>>(models);
            if (sendMessages is null)
            {
                return NotFound();
            }

            return Ok(sendMessages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await _sendMessageService.GetByIdAsync(id);
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] SendMessagePostDTO model)
        {
            var sendMessage = _mapper.Map<SendMessage>(model);
            if (sendMessage is null)
            {
                return BadRequest();
            }

            var validateResult = await _sendMessageValidation.ValidateAsync(sendMessage);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _sendMessageService.AddAsync(sendMessage);
            return Ok(sendMessage);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] SendMessageGetDTO model)
        {
            var sendMessage = await _sendMessageService.GetByIdAsync(model.Id);
            if (sendMessage is null)
            {
                return NotFound();
            }

            sendMessage = _mapper.Map<SendMessage>(model);
            var validateResult = await _sendMessageValidation.ValidateAsync(sendMessage);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            _sendMessageService.Update(sendMessage);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sendMessage = await _sendMessageService.GetByIdAsync(id);
            if (sendMessage is null)
            {
                return NotFound();
            }

            _sendMessageService.Delete(sendMessage);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var sendMessage = await _sendMessageService.GetByIdWithDeletedAsync(id);
            if (sendMessage is null)
            {
                return NotFound();
            }

            _sendMessageService.Destroy(sendMessage);
            return NoContent();
        }
    }
}
