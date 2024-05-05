using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.DTOs.Course;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        readonly ICourseService _courseService;
        readonly IMapper _mapper;
        readonly CourseValidation _validator;
        readonly IImageRepository _imageRepository;
        public CourseController(ICourseService courseService, IMapper mapper, CourseValidation validationRules, IImageRepository imageRepository)
        {
            _courseService = courseService;
            _mapper = mapper;
            _validator = validationRules;
            _imageRepository = imageRepository;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<CourseGetDTO>>> GetAllAsync()
        {
            var models = await _courseService.GetAllAsync();
            var courses = _mapper.Map<List<CourseGetDTO>>(models);
            if (courses is null)
            {
                return NotFound();
            }

            return Ok(courses);
        }

        [HttpPost("add")]
        public async Task<ActionResult<CourseGetDTO>> AddAsync([FromForm] CoursePostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            string filePath = "";
            if (model.ImageFile != null)
            {
                filePath = await _imageRepository.ImageUpload("courses", model.ImageFile);
            }

            var course = _mapper.Map<Course>(model);
            course.Image = filePath;

            var validateResult = await _validator.ValidateAsync(course);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _courseService.AddCouseWithTeachersAsync(course, model.TeacherIds);

            var courseDto = _mapper.Map<CourseGetDTO>(course);
            return Ok(courseDto);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<CourseGetDTO>> UpdateAsync(int id, [FromForm] CoursePostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            string filePath = "";
            if (model.ImageFile != null)
            {
                filePath = await _imageRepository.ImageUpload("courses", model.ImageFile);
            }

            var course = _mapper.Map<Course>(model);
            course.Image = filePath;

            var validateResult = await _validator.ValidateAsync(course);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _courseService.UpdateCourseWithTeachersAsync(id, course, model.TeacherIds);

            var courseDto = _mapper.Map<CourseGetDTO>(course);
            return Ok(courseDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course is null)
            {
                return NotFound();
            }

            _courseService.Delete(course);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var course = await _courseService.GetByIdWithDeletedAsync(id);
            if (course is null)
            {
                return NotFound();
            }

            _courseService.Destroy(course);
            return NoContent();
        }
    }
}