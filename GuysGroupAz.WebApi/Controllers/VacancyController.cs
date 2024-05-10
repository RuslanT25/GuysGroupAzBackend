using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.DTOs.Vacancy;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        readonly IVacancyService _vacancyService;
        readonly IMapper _mapper;
        readonly VacancyValidation _validator;
        public VacancyController(IVacancyService vacancy, IMapper mapper, VacancyValidation validationRules)
        {
            _vacancyService = vacancy;
            _mapper = mapper;
            _validator = validationRules;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<VacancyGetDTO>>> GetAllAsync()
        {
            var models = await _vacancyService.GetAllAsync();
            var vacancies = _mapper.Map<List<VacancyGetDTO>>(models);
            if (vacancies is null)
            {
                return NotFound();
            }

            return Ok(vacancies);
        }

        [HttpPost("add")]
        public async Task<ActionResult<VacancyGetDTO>> AddAsync([FromForm] VacancyPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var vacancy = _mapper.Map<Vacancy>(model);

            var validateResult = await _validator.ValidateAsync(vacancy);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _vacancyService.AddVacancyWithVacancyDetailsAsync(vacancy, model.VacancyDetailIds);

            var blogDto = _mapper.Map<VacancyGetDTO>(vacancy);
            return Ok(blogDto);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<VacancyGetDTO>> UpdateAsync(int id, [FromForm] VacancyPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var vacancy = _mapper.Map<Vacancy>(model);

            var validateResult = await _validator.ValidateAsync(vacancy);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _vacancyService.UpdateVacancyWithVacancyDetailsAsync(id, vacancy, model.VacancyDetailIds);

            var vacacyDto = _mapper.Map<VacancyGetDTO>(vacancy);
            return Ok(vacacyDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vacancy = await _vacancyService.GetByIdAsync(id);
            if (vacancy is null)
            {
                return NotFound();
            }

            _vacancyService.Delete(vacancy);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var vacancy = await _vacancyService.GetByIdWithDeletedAsync(id);
            if (vacancy is null)
            {
                return NotFound();
            }

            _vacancyService.Destroy(vacancy);
            return NoContent();
        }
    }
}