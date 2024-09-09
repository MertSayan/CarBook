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
    public class GetTestimonialQueryHandler : BaseHandler<Testimonial>, IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        public GetTestimonialQueryHandler(IRepository<Testimonial> repository) : base(repository)
        {
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetTestimonialQueryResult
            {
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                TestimonialId = x.TestimonialId,
                Title= x.Title,
            }).ToList();
        }
    }
}
