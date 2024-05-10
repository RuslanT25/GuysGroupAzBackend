using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.DTOs.VacancyDetail;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyDetailController : ControllerBase
    {
        readonly IVacancyDetailsService _vacancyDetailService;
        readonly IMapper _mapper;
        readonly VacancyDetailValidation _validator;
        public VacancyDetailController(IVacancyDetailsService vacancyDetailService, IMapper mapper, VacancyDetailValidation validationRules)
        {
            _vacancyDetailService = vacancyDetailService;
            _mapper = mapper;
            _validator = validationRules;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<VacancyDetailGetDTO>>> GetAllAsync()
        {
            var models = await _vacancyDetailService.GetAllAsync();
            var vacancyDetails = _mapper.Map<List<VacancyDetailGetDTO>>(models);
            if (vacancyDetails is null)
            {
                return NotFound();
            }

            return Ok(vacancyDetails);
        }

        [HttpPost("add")]
        public async Task<ActionResult<VacancyDetailGetDTO>> AddAsync([FromForm] VacancyDetailPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var vacancyDetail = _mapper.Map<VacancyDetail>(model);

            var validateResult = await _validator.ValidateAsync(vacancyDetail);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _vacancyDetailService.AddVacancyDetailWithVacancyDescriptionsAsync(vacancyDetail, model.VacancyDescriptionIds);

            var vacancyDetailDto = _mapper.Map<VacancyDetailGetDTO>(vacancyDetail);
            return Ok(vacancyDetailDto);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<VacancyDetailGetDTO>> UpdateAsync(int id, [FromForm] VacancyDetailPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var vacancyDetail = _mapper.Map<VacancyDetail>(model);

            var validateResult = await _validator.ValidateAsync(vacancyDetail);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _vacancyDetailService.UpdateVacancyDetailWithVacancyDescriptionsAsync(id, vacancyDetail, model.VacancyDescriptionIds);

            var vacancyDetailDto = _mapper.Map<VacancyDetailGetDTO>(vacancyDetail);
            return Ok(vacancyDetailDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vacancyDetail = await _vacancyDetailService.GetByIdAsync(id);
            if (vacancyDetail is null)
            {
                return NotFound();
            }

            _vacancyDetailService.Delete(vacancyDetail);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var vacancyDetail = await _vacancyDetailService.GetByIdWithDeletedAsync(id);
            if (vacancyDetail is null)
            {
                return NotFound();
            }

            _vacancyDetailService.Destroy(vacancyDetail);
            return NoContent();
        }
    }
}