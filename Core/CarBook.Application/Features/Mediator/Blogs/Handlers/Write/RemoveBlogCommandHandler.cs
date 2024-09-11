using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Blogs.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Blogs.Handlers.Write
{
    public class RemoveBlogCommandHandler : BaseHandler<Blog>, IRequestHandler<RemoveBlogCommand>
    {
        public RemoveBlogCommandHandler(IRepository<Blog> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
