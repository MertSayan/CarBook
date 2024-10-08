﻿using CarBook.Application.BaseHandler;
using CarBook.Application.Features.CQRS.Categories.Queries;
using CarBook.Application.Features.CQRS.Categories.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Categories.Handlers.Read
{
    public class GetCategoryByIdQueryHandler : BaseHandler<Category>
    {
        public GetCategoryByIdQueryHandler(IRepository<Category> repository) : base(repository)
        {
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetCategoryByIdQueryResult
            {
                CategoryId = value.CategoryId,
                Name = value.Name
            };
        }
    }
}
