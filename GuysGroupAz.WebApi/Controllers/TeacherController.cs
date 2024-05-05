using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.DTOs.Blog;
using GuysGroupAz.Entity.DTOs.Teacher;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        readonly ITeacherService _teacherService;
        readonly IMapper _mapper;
        readonly TeacherValidation _teacherValidation;
        readonly IImageRepository _imageRepository;
        public TeacherController(ITeacherService teacherService, IMapper mapper, TeacherValidation validationRules, IImageRepository imageRepository)
        {
            _teacherService = teacherService;
            _mapper = mapper;
            _teacherValidation = validationRules;
            _imageRepository = imageRepository;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _teacherService.GetAllAsync();
            var teachers = _mapper.Map<List<TeacherGetDTO>>(models);
            if (teachers is null)
            {
                return NotFound();
            }

            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await _teacherService.GetByIdAsync(id);
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] TeacherPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            string filePath = "";
            if (model.ImageFile != null)
            {
                filePath = await _imageRepository.ImageUpload("teachers", model.ImageFile);
            }

            var teacher = _mapper.Map<Teacher>(model);
            teacher.Image = filePath;

            var validateResult = await _teacherValidation.ValidateAsync(teacher);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _teacherService.AddAsync(teacher);
            return Ok(teacher);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult<TeacherGetDTO>> UpdateAsync(int id, [FromForm] TeacherPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            string filePath = "";
            if (model.ImageFile != null)
            {
                filePath = await _imageRepository.ImageUpload("teachers", model.ImageFile);
            }

            var teacher = _mapper.Map<Teacher>(model);
            teacher.Image = filePath;

            var validateResult = await _teacherValidation.ValidateAsync(teacher);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _teacherService.UpdateTeacherWithCourseAsync(id, teacher, model.CourseId);

            var blogDto = _mapper.Map<TeacherGetDTO>(teacher);
            return Ok(blogDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);
            if (teacher is null)
            {
                return NotFound();
            }

            _teacherService.Delete(teacher);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var teacher = await _teacherService.GetByIdWithDeletedAsync(id);
            if (teacher is null)
            {
                return NotFound();
            }

            _teacherService.Destroy(teacher);
            return NoContent();
        }
    }
}