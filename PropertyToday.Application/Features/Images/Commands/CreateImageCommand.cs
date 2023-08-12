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
    public class CreateImageCommand : IRequest<bool>
    {
        public NewImage _NewImage { get; set; }

        public CreateImageCommand(NewImage newImage)
        {
            _NewImage = newImage;
        }

        //handler
        public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, bool>
        {
            private IImageRepo _imageRepo;
            private IMapper _mapper;

            public CreateImageCommandHandler(IImageRepo imageRepo, IMapper mapper)
            {
                _imageRepo = imageRepo;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CreateImageCommand request, CancellationToken cancellationToken)
            {
                Image image = _mapper.Map<Image>(request._NewImage);
                await _imageRepo.AddNewImageAsync(image);
                return true;
            }
        }


    }
}
