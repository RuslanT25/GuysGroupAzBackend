using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.DAL.Repositories.Concretes;
using GuysGroupAz.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Concretes
{
    public class AboutManager : BaseManager<About>, IAboutService
    {
        private readonly IAboutRepository _repository;
        private readonly IGenericRepository<AboutImage> _aboutImageRepository;

        public AboutManager(IAboutRepository aboutRepository, IGenericRepository<AboutImage> aboutImageRepository) : base(aboutRepository)
        {
            _repository = aboutRepository;
            _aboutImageRepository = aboutImageRepository;
        }

        public async Task AddAboutWithAboutImagesAsync(About about, List<int> aboutImageIds)
        {
            about.AboutImages = await _aboutImageRepository.Where(bi => aboutImageIds.Contains(bi.Id)).ToListAsync();
            await _repository.AddAsync(about);
        }

        public async Task<About> GetByIdEagerAsync(int id)
        {
            return await _repository.GetByIdEagerAsync(id);
        }

        public async Task UpdateAboutWithAboutImagesAsync(int id, About about, List<int> aboutImageIds)
        {
            var existingAbout = await _repository.GetByIdEagerAsync(id) ?? throw new Exception("About tapılmadı.");
            var existingAboutImages = await _aboutImageRepository.Where(bi => existingAbout.AboutImages.Select(b => b.Id).Contains(bi.Id)).ToListAsync();
            existingAbout.AboutImages.RemoveAll(bi => !aboutImageIds.Contains(bi.Id));
            var newBlogImages = await _aboutImageRepository.Where(bi => aboutImageIds.Except(existingAboutImages.Select(bi => bi.Id)).Contains(bi.Id)).ToListAsync();
            existingAbout.AboutImages.AddRange(newBlogImages);

            existingAbout.Title = about.Title;
            existingAbout.Description = about.Description;

            _repository.Update(existingAbout);
        }
    }
}