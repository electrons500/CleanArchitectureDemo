using MediatR;
using PropertyToday.Application.Repositories;
using PropertyToday.Domain;

namespace PropertyToday.Application.Features.Images.Commands
{
    public class DeleteImageCommand : IRequest<bool>
    {
        public int ImageId { get; set; }
        public DeleteImageCommand(int imageId)
        {
            ImageId = imageId;
        }

        //handler
        public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, bool>
        {
            private IImageRepo _imageRepo;
            public DeleteImageCommandHandler(IImageRepo imageRepo)
            {
                _imageRepo = imageRepo;
            }
            public async Task<bool> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
            {
                Image image = await _imageRepo.GetImageByIdAsync(request.ImageId);
                if (image != null)
                {
                    await _imageRepo.DeleteImageAsync(image);
                    return true;
                }
                return false;
            }
        }

    }
}
