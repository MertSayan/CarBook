﻿using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Brands.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Brands.Handlers.Write
{
    public class UpdateBrandCommendHandler : BaseHandler<Brand>
    {
        public UpdateBrandCommendHandler(IRepository<Brand> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateBrandCommand command,int id)
        {
            var value=await _repository.GetByIdAsync(id);
            value.Name = command.Name;
            await _repository.UpdateAsync(value);
        }
    }
}