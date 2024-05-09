using AutoMapper;
using FluentValidation;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.DAL.Repositories.Concretes;
using GuysGroupAz.Entity.DTOs.Course;
using GuysGroupAz.Entity.DTOs.OtherInfo;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherInfoController : ControllerBase
    {
        readonly IOtherInfoService _service;
        readonly IMapper _mapper;
        readonly OtherInfoValidation _validator;
        public OtherInfoController(IOtherInfoService otherInfoService, IMapper mapper, OtherInfoValidation validationRules)
        {
            _service = otherInfoService;
            _mapper = mapper;
            _validator = validationRules;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<OtherInfoGetDTO>>> GetAllAsync()
        {
            var models = await _service.GetAllAsync();
            var otherInfos = _mapper.Map<List<OtherInfoGetDTO>>(models);
            if (otherInfos is null)
            {
                return NotFound();
            }

            return Ok(otherInfos);
        }

        [HttpPost("add")]
        public async Task<ActionResult<OtherInfoGetDTO>> AddAsync([FromForm] OtherInfoPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var otherInfo = _mapper.Map<OtherInfo>(model);

            var validateResult = await _validator.ValidateAsync(otherInfo);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _service.AddOtherInfoWithOtherInfoDescriptionsAsync(otherInfo, model.OtherInfoDescriptionIds);

            var otherInfoDto = _mapper.Map<OtherInfoGetDTO>(otherInfo);
            return Ok(otherInfoDto);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<CourseGetDTO>> UpdateAsync(int id, [FromForm] OtherInfoPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var otherInfo = _mapper.Map<OtherInfo>(model);

            var validateResult = await _validator.ValidateAsync(otherInfo);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _service.UpdateOtherInfoWithOtherInfoDescriptionsAsync(id, otherInfo, model.OtherInfoDescriptionIds);

            var otherInfoDto = _mapper.Map<OtherInfoGetDTO>(otherInfo);
            return Ok(otherInfoDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var otherInfo = await _service.GetByIdAsync(id);
            if (otherInfo is null)
            {
                return NotFound();
            }

            _service.Delete(otherInfo);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var otherInfo = await _service.GetByIdWithDeletedAsync(id);
            if (otherInfo is null)
            {
                return NotFound();
            }

            _service.Destroy(otherInfo);
            return NoContent();
        }
    }
}