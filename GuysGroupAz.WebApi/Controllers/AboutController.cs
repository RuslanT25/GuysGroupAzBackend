using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.DTOs.About;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        readonly IAboutService _aboutService;
        readonly IMapper _mapper;
        readonly AboutValidation _validator;
        public AboutController(IAboutService aboutService, IMapper mapper, AboutValidation validationRules)
        {
            _aboutService = aboutService;
            _mapper = mapper;
            _validator = validationRules;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<AboutGetDTO>>> GetAllAsync()
        {
            var models = await _aboutService.GetAllAsync();
            var abouts = _mapper.Map<List<AboutGetDTO>>(models);
            if (abouts is null)
            {
                return NotFound();
            }

            return Ok(abouts);
        }

        [HttpPost("add")]
        public async Task<ActionResult<AboutGetDTO>> AddAsync([FromForm] AboutPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var about = _mapper.Map<About>(model);
            var validateResult = await _validator.ValidateAsync(about);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _aboutService.AddAboutWithAboutImagesAsync(about, model.AboutImageIds);

            var aboutDto = _mapper.Map<AboutGetDTO>(about);
            return Ok(aboutDto);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<AboutGetDTO>> UpdateAsync(int id, [FromForm] AboutPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var about = _mapper.Map<About>(model);
            var validateResult = await _validator.ValidateAsync(about);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _aboutService.UpdateAboutWithAboutImagesAsync(id, about, model.AboutImageIds);

            var aboutDto = _mapper.Map<AboutGetDTO>(about);
            return Ok(aboutDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            if (about is null)
            {
                return NotFound();
            }

            _aboutService.Delete(about);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var about = await _aboutService.GetByIdWithDeletedAsync(id);
            if (about is null)
            {
                return NotFound();
            }

            _aboutService.Destroy(about);
            return NoContent();
        }
    }
}