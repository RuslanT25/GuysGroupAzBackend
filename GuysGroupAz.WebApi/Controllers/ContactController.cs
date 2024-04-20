using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.Entity.DTOs.Contact;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        readonly IContactService _contactService;
        readonly IMapper _mapper;
        readonly ContactValidation _contactValidation;
        public ContactController(IContactService contactService, IMapper mapper, ContactValidation validationRules)
        {
            _contactService = contactService;
            _mapper = mapper;
            _contactValidation = validationRules;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _contactService.GetAllAsync();
            var contacts = _mapper.Map<List<ContactGetDTO>>(models);
            if (contacts is null)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model= await _contactService.GetByIdAsync(id);
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] ContactPostDTO model)
        {
            var contact = _mapper.Map<Contact>(model);
            if (contact is null)
            {
                return BadRequest();
            }

            var validateResult = await _contactValidation.ValidateAsync(contact);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _contactService.AddAsync(contact);
            return Ok(contact);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] ContactGetDTO model)
        {
            var contact = await _contactService.GetByIdAsync(model.Id);
            if (contact is null)
            {
                return NotFound();
            }

            contact = _mapper.Map<Contact>(model);
            var validateResult = await _contactValidation.ValidateAsync(contact);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }
            
            _contactService.Update(contact);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            if (contact is null)
            {
                return NotFound();
            }

            _contactService.Delete(contact);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var contact = await _contactService.GetByIdWithDeletedAsync(id);
            if (contact is null)
            {
                return NotFound();
            }

            _contactService.Destroy(contact);
            return NoContent();
        }
    }
}