using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.Entity.DTOs.VacancyDescription;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyDescriptionController : ControllerBase
    {
        readonly IVacancyDescriptionService _vacancyDescriptionService;
        readonly IMapper _mapper;
        readonly VacancyDescriptionValidation _vacancyDescriptionValidation;
        public VacancyDescriptionController(IVacancyDescriptionService vacancyDescriptionService, IMapper mapper, VacancyDescriptionValidation validationRules)
        {
            _vacancyDescriptionService = vacancyDescriptionService;
            _mapper = mapper;
            _vacancyDescriptionValidation = validationRules;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _vacancyDescriptionService.GetAllAsync();
            var vacancyDescriptions = _mapper.Map<List<VacancyDescriptionGetDTO>>(models);
            if (vacancyDescriptions is null)
            {
                return NotFound();
            }

            return Ok(vacancyDescriptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await _vacancyDescriptionService.GetByIdAsync(id);
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] VacancyDescriptionPostDTO model)
        {
            var vacancyDescription = _mapper.Map<VacancyDescription>(model);
            if (vacancyDescription is null)
            {
                return BadRequest();
            }

            var validateResult = await _vacancyDescriptionValidation.ValidateAsync(vacancyDescription);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _vacancyDescriptionService.AddAsync(vacancyDescription);
            return Ok(vacancyDescription);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] VacancyDescriptionGetDTO model)
        {
            var vacancyDescription = await _vacancyDescriptionService.GetByIdAsync(model.Id);
            if (vacancyDescription is null)
            {
                return NotFound();
            }

            vacancyDescription = _mapper.Map<VacancyDescription>(model);
            var validateResult = await _vacancyDescriptionValidation.ValidateAsync(vacancyDescription);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            _vacancyDescriptionService.Update(vacancyDescription);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vacancyDescription = await _vacancyDescriptionService.GetByIdAsync(id);
            if (vacancyDescription is null)
            {
                return NotFound();
            }

            _vacancyDescriptionService.Delete(vacancyDescription);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var vacancyDescription = await _vacancyDescriptionService.GetByIdWithDeletedAsync(id);
            if (vacancyDescription is null)
            {
                return NotFound();
            }

            _vacancyDescriptionService.Destroy(vacancyDescription);
            return NoContent();
        }
    }
}