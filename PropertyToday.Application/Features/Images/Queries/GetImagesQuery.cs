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
    public class GetImagesQuery : IRequest<List<GetImagesRequest>>
    {
        //handler
        public class GetImagesQueryHandler : IRequestHandler<GetImagesQuery, List<GetImagesRequest>>
        {
            private IImageRepo ImageRepo;
            private IMapper _mapper;
            public GetImagesQueryHandler(IImageRepo imageRepo, IMapper mapper)
            {
                ImageRepo = imageRepo;
                _mapper = mapper;
            }

            public async Task<List<GetImagesRequest>> Handle(GetImagesQuery request, CancellationToken cancellationToken)
            {
                List<Image> images = await ImageRepo.GetImagesAsync();
                //map
                List<GetImagesRequest> imageList =  _mapper.Map<List<GetImagesRequest>>(images);

                return imageList;
                
            }
        }
    }
}
