using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.Entity.DTOs.Blog;
using GuysGroupAz.Entity.DTOs.Service;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        readonly IServiceService _serviceService;
        readonly IMapper _mapper;
        readonly ServiceValidation _serviceValidation;
        public ServiceController(IServiceService serviceService, IMapper mapper, ServiceValidation validationRules)
        {
            _serviceService = serviceService;
            _mapper = mapper;
            _serviceValidation = validationRules;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _serviceService.GetAllAsync();
            var services = _mapper.Map<List<ServiceGetDTO>>(models);
            if (services is null)
            {
                return NotFound();
            }

            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await _serviceService.GetByIdAsync(id);
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] ServicePostDTO model)
        {
            var service = _mapper.Map<Service>(model);
            if (service is null)
            {
                return BadRequest();
            }

            var validateResult = await _serviceValidation.ValidateAsync(service);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _serviceService.AddServiceWithQuestionsAsync(service, model.QuestionIds);
            return Ok(service);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<BlogGetDTO>> UpdateAsync(int id, [FromForm] ServicePostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var service = _mapper.Map<Service>(model);

            var validateResult = await _serviceValidation.ValidateAsync(service);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _serviceService.UpdateServiceWithQuestionsAsync(id, service, model.QuestionIds);

            var serviceDto = _mapper.Map<ServiceGetDTO>(service);
            return Ok(serviceDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service is null)
            {
                return NotFound();
            }

            _serviceService.Delete(service);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var service = await _serviceService.GetByIdWithDeletedAsync(id);
            if (service is null)
            {
                return NotFound();
            }

            _serviceService.Destroy(service);
            return NoContent();
        }
    }
}