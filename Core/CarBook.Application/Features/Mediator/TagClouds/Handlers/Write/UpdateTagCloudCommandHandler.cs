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
    public class UpdateTagCloudCommandHandler : BaseHandler<TagCloud>, IRequestHandler<UpdateTagCloudCommand>
    {
        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.TagCloudId);
            value.Title = request.Title;
            value.BlogId = request.BlogId;
            await _repository.UpdateAsync(value);
        }
    }
}
