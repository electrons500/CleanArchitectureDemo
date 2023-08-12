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

namespace PropertyToday.Application.Features.Images.Commands
{
    public class UpdateImageCommand : IRequest<bool>
    {
        private UpdateImageRequest _UpdateImageRequest { get; set; }
       
        public UpdateImageCommand(UpdateImageRequest updateImageRequest)
        {
            _UpdateImageRequest = updateImageRequest;
           
        }

        public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommand, bool>
        {
            private IImageRepo _imageRepo;
            private IMapper _mapper;
            public UpdateImageCommandHandler(IMapper mapper, IImageRepo imageRepo)
            {
                _mapper = mapper;
                _imageRepo = imageRepo;
            }
            public async Task<bool> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
            {
                Image image = await _imageRepo.GetImageByIdAsync(request._UpdateImageRequest.Id);
                if (image != null)
                {
                    image.PropertyId = request._UpdateImageRequest.PropertyId;
                    image.Name = request._UpdateImageRequest.Name;
                    image.Path = request._UpdateImageRequest.Path;

                    await  _imageRepo.UpdateImageAsync(image);
                    return true;
                }

                return false;
            }
        }
    }
}
