using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.TagClouds.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.TagClouds.Handlers.Write
{
    public class RemoveTagCloudCommandHandler : BaseHandler<TagCloud>, IRequestHandler<RemoveTagCloudCommend>
    {
        public RemoveTagCloudCommandHandler(IRepository<TagCloud> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveTagCloudCommend request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
