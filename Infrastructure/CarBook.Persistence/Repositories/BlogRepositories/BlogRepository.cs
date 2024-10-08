using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _carbookContext;

        public BlogRepository(CarBookContext carbookContext)
        {
            _carbookContext = carbookContext;
        }

		public async Task<List<Blog>> GetAllBlogsWithAuthors()
		{
			var values= _carbookContext.Blogs.Include(x=>x.Author).OrderByDescending(x => x.BlogId).ToList();
            return values;
		}

        public async Task<List<Blog>> GetBlogByAuthorId(int id)
        {
            var values = _carbookContext.Blogs.Include(x => x.Author).Where(y => y.BlogId == id).ToList();
            return values;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthors()
        {
            var values=_carbookContext.Blogs.Include(x=> x.Author).OrderByDescending(x=>x.BlogId).Take(3).ToList();
            return values;
        }
    }
}
