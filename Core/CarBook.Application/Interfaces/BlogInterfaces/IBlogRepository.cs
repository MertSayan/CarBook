using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        public Task<List<Blog>> GetLast3BlogsWithAuthors();
        public Task<List<Blog>> GetAllBlogsWithAuthors();
        public Task<List<Blog>> GetBlogByAuthorId(int id);
    }
}
