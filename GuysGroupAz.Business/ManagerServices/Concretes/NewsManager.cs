using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Concretes
{
    public class NewsManager : BaseManager<News>, INewsService
    {
        private readonly INewsRepository _repository;
        private readonly IGenericRepository<NewsImage> _newsImageRepository;

        public NewsManager(INewsRepository newsRepository, IGenericRepository<NewsImage> newsImageRepository) : base(newsRepository)
        {
            _repository = newsRepository;
            _newsImageRepository = newsImageRepository;
        }

        public async Task AddNewsWithImagesAsync(News news, List<int> newsImageIds)
        {
            news.NewsImages = await _newsImageRepository.Where(bi => newsImageIds.Contains(bi.Id)).ToListAsync();
            await _repository.AddAsync(news);
        }

        public async Task UpdateNewsWithImagesAsync(int id, News news, List<int> newsImageIds)
        {
            var existingNews = await _repository.GetByIdEagerAsync(id);
            if (existingNews == null)
            {
                throw new Exception("News tapılmadı.");
            }

            var existingNewsImages = await _newsImageRepository.Where(bi => existingNews.NewsImages.Select(b => b.Id).Contains(bi.Id)).ToListAsync();
            existingNews.NewsImages.RemoveAll(bi => !newsImageIds.Contains(bi.Id));
            var newNewsImages = await _newsImageRepository.Where(bi => newsImageIds.Except(existingNewsImages.Select(bi => bi.Id)).Contains(bi.Id)).ToListAsync();
            existingNews.NewsImages.AddRange(newNewsImages);

            existingNews.Title = news.Title;
            existingNews.Description = news.Description;
            existingNews.CoverImage = news.CoverImage;
            existingNews.PublishDate = news.PublishDate;

            _repository.Update(existingNews);
        }
        public async Task<News> GetByIdEagerAsync(int id)
        {
            return await _repository.GetByIdEagerAsync(id);
        }
    }
}