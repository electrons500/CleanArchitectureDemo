using AutoMapper;
using MediatR;
using PropertyToday.Application.Dtos;
using PropertyToday.Application.Repositories;
using PropertyToday.Domain;

namespace PropertyToday.Application.Features.Properties.Queries
{
    public class GetPropertyByIdQuery : IRequest<GetPropertyQuery>
    {
        public int _propertyId { get; set; }
        public GetPropertyByIdQuery(int propertyId)
        {
            _propertyId = propertyId;
        }

        public class GetPropertyByIdQueryHandler : IRequestHandler<GetPropertyByIdQuery, GetPropertyQuery>
        {
            private IPropertyRepo _PropertyRepo;
            private IMapper _mapper;
            public GetPropertyByIdQueryHandler(IPropertyRepo propertyRepo, IMapper mapper)
            {
                _PropertyRepo = propertyRepo;
                _mapper = mapper;
            }
            public async Task<GetPropertyQuery> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
            {
                //check if property exist
                Property property = await _PropertyRepo.GetPropertyAsync(request._propertyId);
                if (property != null)
                {
                   GetPropertyQuery getPropertyQuery = _mapper.Map<GetPropertyQuery>(property);
                    return getPropertyQuery;
                }

                return null;
            }
        }
    }
}
