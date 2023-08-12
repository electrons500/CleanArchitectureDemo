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

namespace PropertyToday.Application.Features.Images.Queries
{
    public class GetImageByIdQuery : IRequest<GetImageRequest>
    {
        private int ImageId { get; set; }
        public GetImageByIdQuery(int imageId)
        {
            ImageId = imageId;
        }

        public class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQuery, GetImageRequest>
        {
            private IImageRepo ImageRepo;
            private IMapper _mapper;
            public GetImageByIdQueryHandler(IImageRepo imageRepo, IMapper mapper)
            {
                ImageRepo = imageRepo;
                _mapper = mapper;
            }
            public async Task<GetImageRequest> Handle(GetImageByIdQuery request, CancellationToken cancellationToken)
            {
                Image image = await ImageRepo.GetImageByIdAsync(request.ImageId);
                GetImageRequest getImage = _mapper.Map<GetImageRequest>(image);
                return getImage;
            }
        }

    }
}
