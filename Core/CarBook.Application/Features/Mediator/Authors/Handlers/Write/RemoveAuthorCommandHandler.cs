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
    public class RemoveAuthorCommandHandler : BaseHandler<Author>, IRequestHandler<RemoveAuthorCommand>
    {
        public RemoveAuthorCommandHandler(IRepository<Author> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
