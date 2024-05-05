using AutoMapper;
using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.DTOs.AboutImage;
using GuysGroupAz.Entity.Models;
using GuysGroupAz.Entity.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuysGroupAz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutImageController : ControllerBase
    {
        readonly IAboutImageService _aboutImageService;
        readonly IMapper _mapper;
        readonly AboutImageValidation _aboutImageValidation;
        readonly IImageRepository _imageRepository;
        public AboutImageController(IAboutImageService aboutImageService, IMapper mapper, AboutImageValidation validationRules, IImageRepository imageRepository)
        {
            _aboutImageService = aboutImageService;
            _mapper = mapper;
            _aboutImageValidation = validationRules;
            _imageRepository = imageRepository;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _aboutImageService.GetAllAsync();
            var aboutImages = _mapper.Map<List<AboutImageGetDTO>>(models);
            if (aboutImages is null)
            {
                return NotFound();
            }

            return Ok(aboutImages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await _aboutImageService.GetByIdAsync(id);
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] AboutImagePostDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            string filePath = "";
            if (model.ImageFile != null)
            {
                filePath = await _imageRepository.ImageUpload("aboutimages", model.ImageFile);
            }

            var aboutImage = _mapper.Map<AboutImage>(model);
            aboutImage.Image = filePath;

            var validateResult = await _aboutImageValidation.ValidateAsync(aboutImage);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _aboutImageService.AddAsync(aboutImage);
            return Ok(aboutImage);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromForm] AboutImagePostDTO model)
        {
            var aboutImage = await _aboutImageService.GetByIdAsync(id);
            if (aboutImage is null)
            {
                return NotFound();
            }

            if (model.ImageFile != null)
            {
                _imageRepository.DeleteImage("aboutimages", aboutImage.Image);
                aboutImage.Image = await _imageRepository.ImageUpload("aboutimages", model.ImageFile);
            }

            aboutImage.Name = model.Name;

            var validateResult = await _aboutImageValidation.ValidateAsync(aboutImage);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            _aboutImageService.Update(aboutImage);
            return NoContent();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var aboutImage = await _aboutImageService.GetByIdAsync(id);
            if (aboutImage is null)
            {
                return NotFound();
            }

            _aboutImageService.Delete(aboutImage);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var aboutImage = await _aboutImageService.GetByIdWithDeletedAsync(id);
            if (aboutImage is null)
            {
                return NotFound();
            }

            _aboutImageService.Destroy(aboutImage);
            return NoContent();
        }
    }
}