using MediatR;
using PropertyToday.Application.Repositories;
using PropertyToday.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyToday.Application.Features.Properties.Commands
{
    public class DeletePropertyCommand : IRequest<bool>
    {
        public int _propertyId { get; set; }
        public DeletePropertyCommand(int propertyId)
        {
            _propertyId = propertyId;
        }

        //handler
        public class DeletePropertyCommandHandler : IRequestHandler<DeletePropertyCommand, bool>
        {
            private IPropertyRepo _propertyRepo;
            public DeletePropertyCommandHandler(IPropertyRepo propertyRepo)
            {
                _propertyRepo = propertyRepo;
            }
            public async Task<bool> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
            {
                Property property = await _propertyRepo.GetPropertyAsync(request._propertyId);
                if (property != null)
                {
                    await _propertyRepo.DeletePropertyAsync(property);
                    return true;
                }

                return false;
            }
        }
    }
}
