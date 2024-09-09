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
    public class RemoveTestimonialCommandHandler : BaseHandler<Testimonial>, IRequestHandler<RemoveTestimonialCommand>
    {
        public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value= await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
