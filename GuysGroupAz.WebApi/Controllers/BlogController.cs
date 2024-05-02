using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.DTOs.Blog;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        readonly IBlogService _blogService;
        readonly IMapper _mapper;
        readonly BlogValidation _validator;
        readonly IImageRepository _imageRepository;
        public BlogController(IBlogService blogService, IMapper mapper, BlogValidation validationRules, IImageRepository imageRepository)
        {
            _blogService = blogService;
            _mapper = mapper;
            _validator = validationRules;
            _imageRepository = imageRepository;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<BlogGetDTO>>> GetAllAsync()
        {
            var models = await _blogService.GetAllAsync();
            var blogs = _mapper.Map<List<BlogGetDTO>>(models);
            if (blogs is null)
            {
                return NotFound();
            }

            return Ok(blogs);
        }

        [HttpPost("add")]
        public async Task<ActionResult<BlogGetDTO>> AddAsync([FromForm]BlogPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            string filePath = "";
            if (model.CoverImageFile != null)
            {
                filePath = await _imageRepository.ImageUpload("blogs", model.CoverImageFile);
            }

            var blog = _mapper.Map<Blog>(model);
            blog.CoverImage = filePath;

            var validateResult = await _validator.ValidateAsync(blog);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _blogService.AddBlogWithImagesAsync(blog, model.BlogImageIds);

            var blogDto = _mapper.Map<BlogGetDTO>(blog);
            return Ok(blogDto);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<BlogGetDTO>> UpdateAsync(int id, [FromForm] BlogPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            string filePath = "";
            if (model.CoverImageFile != null)
            {
                filePath = await _imageRepository.ImageUpload("blogs", model.CoverImageFile);
            }

            var blog = _mapper.Map<Blog>(model);
            blog.CoverImage = filePath;

            var validateResult = await _validator.ValidateAsync(blog);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _blogService.UpdateBlogWithImagesAsync(id, blog, model.BlogImageIds);

            var blogDto = _mapper.Map<BlogGetDTO>(blog);
            return Ok(blogDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog is null)
            {
                return NotFound();
            }   

            _blogService.Delete(blog);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var blog = await _blogService.GetByIdWithDeletedAsync(id);
            if (blog is null)
            {
                return NotFound();
            }

            _blogService.Destroy(blog);
            return NoContent();
        }
    }
}