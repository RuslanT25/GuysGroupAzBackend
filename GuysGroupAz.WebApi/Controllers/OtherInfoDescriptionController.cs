using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.DAL.Repositories.Concretes;
using GuysGroupAz.Entity.DTOs.OtherInfoDescription;
using GuysGroupAz.Entity.DTOs.Teacher;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherInfoDescriptionController : ControllerBase
    {
        readonly IOtherInfoDescriptionService _service;
        readonly IMapper _mapper;
        readonly OtherInfoDescriptionValidation _validation;
        public OtherInfoDescriptionController(IOtherInfoDescriptionService otherInfoDescriptionService, IMapper mapper, OtherInfoDescriptionValidation validationRules)
        {
            _service = otherInfoDescriptionService;
            _mapper = mapper;
            _validation = validationRules;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _service.GetAllAsync();
            var otherInfoDescriptions = _mapper.Map<List<OtherInfoDescriptionGetDTO>>(models);
            if (otherInfoDescriptions is null)
            {
                return NotFound();
            }

            return Ok(otherInfoDescriptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await _service.GetByIdAsync(id);
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] OtherInfoDescriptionPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }
            var otherInfoDescription = _mapper.Map<OtherInfoDescription>(model);

            var validateResult = await _validation.ValidateAsync(otherInfoDescription);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _service.AddAsync(otherInfoDescription);
            return Ok(otherInfoDescription);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<OtherInfoDescriptionGetDTO>> UpdateAsync(int id, [FromForm] TeacherPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var otherInfoDescription = _mapper.Map<OtherInfoDescription>(model);

            var validateResult = await _validation.ValidateAsync(otherInfoDescription);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _service.UpdateOtherInfoDescriptionWithOtherInfoAsync(id, otherInfoDescription, model.CourseId);

            var otherInfoDesciptionDto = _mapper.Map<OtherInfoDescriptionGetDTO>(otherInfoDescription);
            return Ok(otherInfoDesciptionDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var otherInfoDescription = await _service.GetByIdAsync(id);
            if (otherInfoDescription is null)
            {
                return NotFound();
            }

            _service.Delete(otherInfoDescription);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var otherInfoDescription = await _service.GetByIdWithDeletedAsync(id);
            if (otherInfoDescription is null)
            {
                return NotFound();
            }

            _service.Destroy(otherInfoDescription);
            return NoContent();
        }
    }
}