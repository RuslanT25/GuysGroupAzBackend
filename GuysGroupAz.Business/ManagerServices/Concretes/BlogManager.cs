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
    public class BlogManager : BaseManager<Blog>, IBlogService
    {
        private readonly IBlogRepository _repository;
        private readonly IGenericRepository<BlogImage> _blogImageRepository;

        public BlogManager(IBlogRepository blogRepository, IGenericRepository<BlogImage> blogImageRepository) : base(blogRepository)
        {
            _repository = blogRepository;
            _blogImageRepository = blogImageRepository;
        }

        public async Task AddBlogWithImagesAsync(Blog blog, List<int> blogImageIds)
        {
            blog.BlogImages = await _blogImageRepository.Where(bi => blogImageIds.Contains(bi.Id)).ToListAsync();
            await _repository.AddAsync(blog);
        }

        public async Task UpdateBlogWithImagesAsync(int id, Blog blog, List<int> blogImageIds)
        {
            var existingBlog = await _repository.GetByIdEagerAsync(id);
            if (existingBlog == null)
            {
                throw new Exception("Blog not found");
            }

            var existingBlogImages = await _blogImageRepository.Where(bi => existingBlog.BlogImages.Select(b => b.Id).Contains(bi.Id)).ToListAsync();
            existingBlog.BlogImages.RemoveAll(bi => !blogImageIds.Contains(bi.Id));
            var newBlogImages = await _blogImageRepository.Where(bi => blogImageIds.Except(existingBlogImages.Select(bi => bi.Id)).Contains(bi.Id)).ToListAsync();
            existingBlog.BlogImages.AddRange(newBlogImages);

            existingBlog.Title = blog.Title;
            existingBlog.Description = blog.Description;
            existingBlog.CoverImage = blog.CoverImage;
            existingBlog.PublishDate = blog.PublishDate;

            _repository.Update(existingBlog);
        }
        public async Task<Blog> GetByIdEagerAsync(int id)
        {
            return await _repository.GetByIdEagerAsync(id);
        }
    }
}