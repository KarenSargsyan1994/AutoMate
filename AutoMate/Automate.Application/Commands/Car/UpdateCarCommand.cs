using AutoMapper;
using Automate.Application.DataTransferObjects.Car;
using Automate.Application.Services.Interfaces;
using MediatR;

namespace Automate.Application.Commands.Car
{
    public sealed record UpdateCarCommand(CarDto Car) : IRequest; 

    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        private readonly ICarService _carService;

        public UpdateCarCommandHandler(ICarService carService)
        {
            _carService=carService;
        }

        public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            if (request.Car is not null)
            {
                var car = await _carService.GetByIdAsync(request.Car.Id);
                if (car is not null)
                {
                    await _carService.UpdateAsync(request.Car.Id, request.Car);
                }
            }
        }
    }
}
