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
    public class UpdateAuthorCommandHandler : BaseHandler<Author>, IRequestHandler<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandHandler(IRepository<Author> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.AuthorId);
            value.Description = request.Description;
            value.ImageUrl = request.ImageUrl;
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
