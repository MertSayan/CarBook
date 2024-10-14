using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.Where(e => e.DeletedDate == null).Select(x => new Comment
            {
                CommentId = x.CommentId,
                BlogId = x.BlogId,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Name = x.Name,
            }).ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public List<Comment> GetCommetsByBlogId(int id)
        {
            return _context.Set<Comment>().Where(x=>x.BlogId == id).ToList();
        }
    
        public void Remove(Comment entity)
        {
            var value= _context.Comments.Find(entity.CommentId);
            value.DeletedDate = DateTime.Now;
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
