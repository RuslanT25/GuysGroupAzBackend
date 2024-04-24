using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.Entity.DTOs.Subcribe;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        readonly ISubscribeService _subscribeService;
        readonly IMapper _mapper;
        readonly SubscribeValidation _subscribeValidation;
        public SubscribeController(ISubscribeService subscribeService, IMapper mapper, SubscribeValidation validationRules)
        {
            _subscribeService = subscribeService;
            _mapper = mapper;
            _subscribeValidation = validationRules;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _subscribeService.GetAllAsync();
            var subscribes = _mapper.Map<List<SubscribeGetDTO>>(models);
            if (subscribes is null)
            {
                return NotFound();
            }

            return Ok(subscribes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await _subscribeService.GetByIdAsync(id);
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] SubscribePostDTO model)
        {
            var subscribe = _mapper.Map<Subscribe>(model);
            if (subscribe is null)
            {
                return BadRequest();
            }

            var validateResult = await _subscribeValidation.ValidateAsync(subscribe);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _subscribeService.AddAsync(subscribe);
            return Ok(subscribe);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] SubscribeGetDTO model)
        {
            var subscribe = await _subscribeService.GetByIdAsync(model.Id);
            if (subscribe is null)
            {
                return NotFound();
            }

            subscribe = _mapper.Map<Subscribe>(model);
            var validateResult = await _subscribeValidation.ValidateAsync(subscribe);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            _subscribeService.Update(subscribe);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subscribe = await _subscribeService.GetByIdAsync(id);
            if (subscribe is null)
            {
                return NotFound();
            }

            _subscribeService.Delete(subscribe);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var subscribe = await _subscribeService.GetByIdWithDeletedAsync(id);
            if (subscribe is null)
            {
                return NotFound();
            }

            _subscribeService.Destroy(subscribe);
            return NoContent();
        }
    }
}
