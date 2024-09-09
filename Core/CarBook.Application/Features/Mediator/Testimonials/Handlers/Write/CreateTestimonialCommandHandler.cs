﻿using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Testimonials.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Testimonials.Handlers.Write
{
    public class CreateTestimonialCommandHandler : BaseHandler<Testimonial>, IRequestHandler<CreateTestimonialCommand>
    {
        public CreateTestimonialCommandHandler(IRepository<Testimonial> repository) : base(repository)
        {
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Testimonial
            {
                Title = request.Title,
                Name = request.Name,
                ImageUrl = request.ImageUrl,
                Comment = request.Comment,
                
            });
        }
    }
}
