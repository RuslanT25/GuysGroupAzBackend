using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.DTOs.BlogImage;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogImageController : ControllerBase
    {
        readonly IBlogImageService _blogImageService;
        readonly IMapper _mapper;
        readonly BlogImageValidation _blogImageValidation;
        readonly IImageRepository _imageRepository;
        public BlogImageController(IBlogImageService blogImageService, IMapper mapper, BlogImageValidation validationRules, IImageRepository imageRepository)
        {
            _blogImageService = blogImageService;
            _mapper = mapper;
            _blogImageValidation = validationRules;
            _imageRepository = imageRepository;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _blogImageService.GetAllAsync();
            var blogImages = _mapper.Map<List<BlogImageGetDTO>>(models);
            if (blogImages is null)
            {
                return NotFound();
            }

            return Ok(blogImages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await _blogImageService.GetByIdAsync(id);
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] BlogImagePostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            string filePath = "";
            if (model.ImageFile != null)
            {
                filePath = await _imageRepository.ImageUpload("blogimages", model.ImageFile);
            }

            var blogImage = _mapper.Map<BlogImage>(model);
            blogImage.Image = filePath;

            var validateResult = await _blogImageValidation.ValidateAsync(blogImage);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _blogImageService.AddAsync(blogImage);
            return Ok(blogImage);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromForm] BlogImagePostDTO model)
        {
            var blogImage = await _blogImageService.GetByIdAsync(id);
            if (blogImage is null)
            {
                return NotFound();
            }

            if (model.ImageFile != null)
            {
                _imageRepository.DeleteImage("blogimages", blogImage.Image);
                blogImage.Image = await _imageRepository.ImageUpload("blogimages", model.ImageFile);
            }

            blogImage.Name = model.Name;

            var validateResult = await _blogImageValidation.ValidateAsync(blogImage);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            _blogImageService.Update(blogImage);
            return NoContent();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blogImage = await _blogImageService.GetByIdAsync(id);
            if (blogImage is null)
            {
                return NotFound();
            }

            _blogImageService.Delete(blogImage);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var blogImage = await _blogImageService.GetByIdWithDeletedAsync(id);
            if (blogImage is null)
            {
                return NotFound();
            }

            _blogImageService.Destroy(blogImage);
            return NoContent();
        }
    }
}