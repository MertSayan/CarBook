using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Banners.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Banners.Handlers.Write
{
    public class RemoveBannerCommandHandler : BaseHandler<Banner>
    {
        public RemoveBannerCommandHandler(IRepository<Banner> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveBannerCommand command)
        {
            var value=await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
