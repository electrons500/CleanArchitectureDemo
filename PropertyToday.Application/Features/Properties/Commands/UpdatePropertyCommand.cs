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

namespace PropertyToday.Application.Features.Properties.Commands
{
    public class UpdatePropertyCommand : IRequest<bool>
    {

        public UpdatePropertyRequest UpdatePropertyRequest { get; set; }
        public UpdatePropertyCommand(UpdatePropertyRequest updatePropertyRequest)
        {
            UpdatePropertyRequest = updatePropertyRequest;
        }

        //handler
        public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, bool>
        {
            private IPropertyRepo _propertyRepo;
            private IMapper _mapper;
            public UpdatePropertyCommandHandler(IPropertyRepo propertyRepo, IMapper mapper)
            {
                _propertyRepo = propertyRepo;
                _mapper = mapper;
            }
            public async Task<bool> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
            {
                Property property = await _propertyRepo.GetPropertyAsync(request.UpdatePropertyRequest.Id);
                if (property != null)
                {
                    property.Name = request.UpdatePropertyRequest.Name;
                    property.Description = request.UpdatePropertyRequest.Description;
                    property.Type = request.UpdatePropertyRequest.Type;
                    property.ErfSize = request.UpdatePropertyRequest.ErfSize;
                    property.FloorSize = request.UpdatePropertyRequest.FloorSize;
                    property.Price = request.UpdatePropertyRequest.Price;
                    property.Levies = request.UpdatePropertyRequest.Levies;
                    property.Rates = request.UpdatePropertyRequest.Rates;
                    property.Address = request.UpdatePropertyRequest.Address;
                    property.PetsAllowed = request.UpdatePropertyRequest.PetsAllowed;
                    property.Bedrooms = request.UpdatePropertyRequest.Bathrooms;
                    property.Bathrooms = request.UpdatePropertyRequest.Bathrooms;
                    property.Kitchens = request.UpdatePropertyRequest.Kitchens;
                    property.Louge = request.UpdatePropertyRequest.Louge;
                    property.Dining = request.UpdatePropertyRequest.Dining;

                    await _propertyRepo.UpdatePropertyAsync(property);

                    return true;
                }

                return false;
            }
        }
    }
}
