using AutoMapper;
using MediatR;
using PropertyToday.Application.Dtos;
using PropertyToday.Application.Repositories;
using PropertyToday.Domain;

namespace PropertyToday.Application.Features.Properties.Commands
{
    public class CreatePropertyCommand : IRequest<bool>
    {
        public NewPropertyRequest PropertyRequest { get; set; }
        public CreatePropertyCommand(NewPropertyRequest newPropertyRequest)
        {
            PropertyRequest = newPropertyRequest;
        }

        public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, bool>
        {
            private IPropertyRepo _propertyRepo;
            private IMapper _mapper;
            public CreatePropertyCommandHandler(IPropertyRepo propertyRepo, IMapper mapper)
            {
                _propertyRepo = propertyRepo;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
            {
                Property property = _mapper.Map<Property>(request.PropertyRequest);
                property.ListDate = DateTime.Now;

                await _propertyRepo.AddNewPropertyAsync(property);

                return true;

            }
        }
    }
}
