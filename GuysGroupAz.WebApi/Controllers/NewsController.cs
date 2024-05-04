using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.DTOs.News;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        readonly INewsService _newsService;
        readonly IMapper _mapper;
        readonly NewsValidation _validator;
        readonly IImageRepository _imageRepository;
        public NewsController(INewsService newsService, IMapper mapper, NewsValidation validationRules, IImageRepository imageRepository)
        {
            _newsService = newsService;
            _mapper = mapper;
            _validator = validationRules;
            _imageRepository = imageRepository;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<NewsGetDTO>>> GetAllAsync()
        {
            var models = await _newsService.GetAllAsync();
            var newss = _mapper.Map<List<NewsGetDTO>>(models);
            if (newss is null)
            {
                return NotFound();
            }

            return Ok(newss);
        }

        [HttpPost("add")]
        public async Task<ActionResult<NewsGetDTO>> AddAsync([FromForm] NewsPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            string filePath = "";
            if (model.CoverImageFile != null)
            {
                filePath = await _imageRepository.ImageUpload("newss", model.CoverImageFile);
            }

            var news = _mapper.Map<News>(model);
            news.CoverImage = filePath;

            var validateResult = await _validator.ValidateAsync(news);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _newsService.AddNewsWithImagesAsync(news, model.NewsImageIds);

            var newsDto = _mapper.Map<NewsGetDTO>(news);
            return Ok(newsDto);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<NewsGetDTO>> UpdateAsync(int id, [FromForm] NewsPostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            string filePath = "";
            if (model.CoverImageFile != null)
            {
                filePath = await _imageRepository.ImageUpload("newss", model.CoverImageFile);
            }

            var news = _mapper.Map<News>(model);
            news.CoverImage = filePath;

            var validateResult = await _validator.ValidateAsync(news);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _newsService.UpdateNewsWithImagesAsync(id, news, model.NewsImageIds);

            var newsDto = _mapper.Map<NewsGetDTO>(news);
            return Ok(newsDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var news = await _newsService.GetByIdAsync(id);
            if (news is null)
            {
                return NotFound();
            }

            _newsService.Delete(news);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var news = await _newsService.GetByIdWithDeletedAsync(id);
            if (news is null)
            {
                return NotFound();
            }

            _newsService.Destroy(news);
            return NoContent();
        }
    }
}