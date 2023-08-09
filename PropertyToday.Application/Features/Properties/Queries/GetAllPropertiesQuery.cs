using AutoMapper;
using MediatR;
using PropertyToday.Application.Dtos;
using PropertyToday.Application.Repositories;
using PropertyToday.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyToday.Application.Features.Properties.Queries
{
    public class GetAllPropertiesQuery : IRequest<List<GetPropertyQuery>>
    {
        
        public class GetAllPropertiesQueryHandler : IRequestHandler<GetAllPropertiesQuery, List<GetPropertyQuery>>
        {
            private IPropertyRepo _propertyRepo;
            private IMapper _mapper;
            public GetAllPropertiesQueryHandler(IPropertyRepo propertyRepo, IMapper mapper)
            {
                _propertyRepo = propertyRepo;
                _mapper = mapper;
            }
            public async Task<List<GetPropertyQuery>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
            {
                List<Property> properties = await _propertyRepo.GetAllPropertiesAsync();
                if(properties != null)
                {
                    //Map
                    List<GetPropertyQuery> model = _mapper.Map<List<GetPropertyQuery>>(properties);
                    return model;

                }

                return null;
            }
        }
    }
}
