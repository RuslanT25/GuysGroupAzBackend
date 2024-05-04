using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.DTOs.NewsImage;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsImageController : ControllerBase
    {
        readonly INewsImageService _newsImageService;
        readonly IMapper _mapper;
        readonly NewsImageValidation _newsImageValidation;
        readonly IImageRepository _imageRepository;
        public NewsImageController(INewsImageService newsImageService, IMapper mapper, NewsImageValidation validationRules, IImageRepository imageRepository)
        {
            _newsImageService = newsImageService;
            _mapper = mapper;
            _newsImageValidation = validationRules;
            _imageRepository = imageRepository;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _newsImageService.GetAllAsync();
            var newsImages = _mapper.Map<List<NewsImageGetDTO>>(models);
            if (newsImages is null)
            {
                return NotFound();
            }

            return Ok(newsImages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await _newsImageService.GetByIdAsync(id);
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] NewsImagePostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            string filePath = "";
            if (model.ImageFile != null)
            {
                filePath = await _imageRepository.ImageUpload("newsimages", model.ImageFile);
            }

            var newsImage = _mapper.Map<NewsImage>(model);
            newsImage.Image = filePath;

            var validateResult = await _newsImageValidation.ValidateAsync(newsImage);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _newsImageService.AddAsync(newsImage);
            return Ok(newsImage);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromForm] NewsImagePostDTO model)
        {
            var newsImage = await _newsImageService.GetByIdAsync(id);
            if (newsImage is null)
            {
                return NotFound();
            }

            if (model.ImageFile != null)
            {
                _imageRepository.DeleteImage("newss", newsImage.Image);
                newsImage.Image = await _imageRepository.ImageUpload("newss", model.ImageFile);
            }

            newsImage.Name = model.Name;

            var validateResult = await _newsImageValidation.ValidateAsync(newsImage);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            _newsImageService.Update(newsImage);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var newsImage = await _newsImageService.GetByIdAsync(id);
            if (newsImage is null)
            {
                return NotFound();
            }

            _newsImageService.Delete(newsImage);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var newsImage = await _newsImageService.GetByIdWithDeletedAsync(id);
            if (newsImage is null)
            {
                return NotFound();
            }

            _newsImageService.Destroy(newsImage);
            return NoContent();
        }
    }
}