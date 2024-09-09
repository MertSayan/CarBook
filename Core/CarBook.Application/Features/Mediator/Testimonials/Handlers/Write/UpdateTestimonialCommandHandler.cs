using CarBook.Application.BaseHandler;
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
    public class UpdateTestimonialCommandHandler : BaseHandler<Testimonial>, IRequestHandler<UpdateTestimonialCommand>
    {
        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.TestimonialId);
            value.Title = request.Title;
            value.Comment = request.Comment;
            value.Name = request.Name;
            value.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
