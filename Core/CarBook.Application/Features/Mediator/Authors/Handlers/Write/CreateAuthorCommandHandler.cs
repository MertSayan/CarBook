using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Authors.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Authors.Handlers.Write
{
    public class CreateAuthorCommandHandler : BaseHandler<Author>, IRequestHandler<CreateAuthorCommand>
    {
        public CreateAuthorCommandHandler(IRepository<Author> repository) : base(repository)
        {
        }

        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Author
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
            });
        }
    }
}
