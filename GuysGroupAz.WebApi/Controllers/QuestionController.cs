using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.Entity.DTOs.Question;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        readonly IQuestionService _questionService;
        readonly IMapper _mapper;
        readonly QuestionValidation _questionValidation;
        public QuestionController(IQuestionService questionService, IMapper mapper, QuestionValidation validationRules)
        {
            _questionService = questionService;
            _mapper = mapper;
            _questionValidation = validationRules;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _questionService.GetAllAsync();
            var questions = _mapper.Map<List<QuestionGetDTO>>(models);
            if (questions is null)
            {
                return NotFound();
            }

            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await _questionService.GetByIdAsync(id);
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] QuestionPostDTO model)
        {
            var question = _mapper.Map<Question>(model);
            if (question is null)
            {
                return BadRequest();
            }

            var validateResult = await _questionValidation.ValidateAsync(question);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _questionService.AddAsync(question);
            return Ok(question);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] QuestionGetDTO model)
        {
            var question = await _questionService.GetByIdAsync(model.Id);
            if (question is null)
            {
                return NotFound();
            }

            question = _mapper.Map<Question>(model);
            var validateResult = await _questionValidation.ValidateAsync(question);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            _questionService.Update(question);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var question = await _questionService.GetByIdAsync(id);
            if (question is null)
            {
                return NotFound();
            }

            _questionService.Delete(question);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var question = await _questionService.GetByIdWithDeletedAsync(id);
            if (question is null)
            {
                return NotFound();
            }

            _questionService.Destroy(question);
            return NoContent();
        }
    }
}