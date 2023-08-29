using AutoMapper;
using Automate.Application.DataTransferObjects.Car;
using Automate.Application.Repositories;
using Automate.Application.Services.Interfaces;
using MediatR;

namespace Automate.Application.Commands.Car
{
    public sealed record CreateCarCommand(CarDto Car) : IRequest;    

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly ICarService _carService;
        public CreateCarCommandHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            if (request.Car is not null)
            {
                await _carService.AddAsync(request.Car);
            }
        }
    }
}
