using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Testimonials.Queries;
using CarBook.Application.Features.Mediator.Testimonials.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Testimonials.Handlers.Read
{
    public class GetTestimonialByIdQueryHandler : BaseHandler<Testimonial>, IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository) : base(repository)
        {
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value= await _repository.GetByIdAsync(request.Id);
            return new GetTestimonialByIdQueryResult
            {
                Title = value.Title,
                Comment = value.Comment,
                ImageUrl = value.ImageUrl,
                Name = value.Name,
                TestimonialId = value.TestimonialId
            };
        }
    }
}
