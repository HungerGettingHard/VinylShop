using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;

namespace Persistence.Services
{
    public class OrderDestinationService : IOrderDestinationService
    {
        private readonly IGenericRepository<OrderDestination> _repository;
        private readonly IValidationService<OrderDestinationRequestDto> _validator;

        public OrderDestinationService(IUnitOfWork unitOfWork, IValidationService<OrderDestinationRequestDto> validator)
        {
            _repository = unitOfWork.OrderDestinationRepository;
            _validator = validator;
        }

        public List<OrderDestinationResponseDto> GetAllOrderDestinations()
        {
            return _repository.GetList()
                .Select(destination => new OrderDestinationResponseDto
                {
                    Id = destination.Id,
                    Name = destination.Name
                })
                .OrderBy(destination => destination.Name)
                .ToList();
        }

        public OrderDestinationResponseDto GetOrderDestinationById(Guid id)
        {
            var destination = FindDestinationInRepositoryByIdAndThrow(id);

            return new OrderDestinationResponseDto
            {
                Id = destination.Id,
                Name = destination.Name
            };
        }

        public void SetOrderDestination(OrderDestinationRequestDto orderDestinationDto)
        {
            _validator.Validate(orderDestinationDto);

            _repository.Insert(new OrderDestination
            {
                Name = orderDestinationDto.Name,
            });
        }

        public void DeleteOrderDestinationById(Guid id)
        {
            var destination = FindDestinationInRepositoryByIdAndThrow(id);

            _repository.Delete(destination);
        }

        public void UpdateOrderDestination(Guid id, OrderDestinationRequestDto orderDestinationDto)
        {
            _validator.Validate(orderDestinationDto);
            var destination = FindDestinationInRepositoryByIdAndThrow(id);

            destination.Name = orderDestinationDto.Name;

            _repository.SaveChanges();
        }

        private OrderDestination FindDestinationInRepositoryByIdAndThrow(Guid id)
        {
            var destination = _repository.GetByID(id);

            if (destination == null)
                throw new NotFoundException(nameof(OrderDestination), id);

            return destination;
        }
    }
}
