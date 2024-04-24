using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.Entity.DTOs.GeneralInfo;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralInfoController : ControllerBase
    {
        readonly IGeneralInfoService _generalInfoService;
        readonly IMapper _mapper;
        readonly GeneralInfoValidation _generalInfoValidation;
        public GeneralInfoController(IGeneralInfoService generalInfoService, IMapper mapper, GeneralInfoValidation validationRules)
        {
            _generalInfoService = generalInfoService;
            _mapper = mapper;
            _generalInfoValidation = validationRules;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _generalInfoService.GetAllAsync();
            var generalInfos = _mapper.Map<List<GeneralInfoGetDTO>>(models);
            if (generalInfos is null)
            {
                return NotFound();
            }

            return Ok(generalInfos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await _generalInfoService.GetByIdAsync(id);
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] GeneralInfoPostDTO model)
        {
            var generalInfo = _mapper.Map<GeneralInfo>(model);
            if (generalInfo is null)
            {
                return BadRequest();
            }

            var validateResult = await _generalInfoValidation.ValidateAsync(generalInfo);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _generalInfoService.AddAsync(generalInfo);
            return Ok(generalInfo);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] GeneralInfoGetDTO model)
        {
            var generalInfo = await _generalInfoService.GetByIdAsync(model.Id);
            if (generalInfo is null)
            {
                return NotFound();
            }

            generalInfo = _mapper.Map<GeneralInfo>(model);
            var validateResult = await _generalInfoValidation.ValidateAsync(generalInfo);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            _generalInfoService.Update(generalInfo);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var generalInfo = await _generalInfoService.GetByIdAsync(id);
            if (generalInfo is null)
            {
                return NotFound();
            }

            _generalInfoService.Delete(generalInfo);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var generalInfo = await _generalInfoService.GetByIdWithDeletedAsync(id);
            if (generalInfo is null)
            {
                return NotFound();
            }

            _generalInfoService.Destroy(generalInfo);
            return NoContent();
        }
    }
}