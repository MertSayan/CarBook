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
    public class CreateTagCloudCommandHandler : BaseHandler<TagCloud>, IRequestHandler<CreateTagCloudCommand>
    {
        public CreateTagCloudCommandHandler(IRepository<TagCloud> repository) : base(repository)
        {
        }

        public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new TagCloud
            {
                BlogId = request.BlogId,
                Title = request.Title,
            });
        }
    }
}
