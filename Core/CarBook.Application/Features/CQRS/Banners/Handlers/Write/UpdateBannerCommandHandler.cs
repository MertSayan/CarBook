﻿using CarBook.Application.BaseHandler;
using CarBook.Application.Features.CQRS.Banners.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Banners.Handlers.Write
{
    public class UpdateBannerCommandHandler : BaseHandler<Banner>
    {
        public UpdateBannerCommandHandler(IRepository<Banner> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BannerId);
            values.Title = command.Title;
            values.Description = command.Description;
            values.VideoDescription = command.VideoDescription;
            values.VideoUrl = command.VideoUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
