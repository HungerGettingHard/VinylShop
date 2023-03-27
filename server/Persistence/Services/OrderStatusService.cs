using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;

namespace Persistence.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IGenericRepository<OrderStatus> _repository;
        private readonly IValidationService<OrderStatusRequestDto> _validator;

        public OrderStatusService(IUnitOfWork unitOfWork, IValidationService<OrderStatusRequestDto> validator)
        {
            _repository = unitOfWork.OrderStatusRepository;
            _validator = validator;
        }

        public List<OrderStatusResponseDto> GetAllOrderStatuses()
        {
            return _repository.GetList()
                .Select(status => new OrderStatusResponseDto
                {
                    Id = status.Id,
                    Name = status.Name
                })
                .OrderBy(status => status.Name)
                .ToList();
        }

        public OrderStatusResponseDto GetOrderStatusById(Guid id)
        {
            var status = FindStatusInRepositoryByIdAndThrow(id);

            return new OrderStatusResponseDto
            {
                Id = status.Id,
                Name = status.Name
            };
        }

        public void SetOrderStatus(OrderStatusRequestDto orderStatusDto)
        {
            _validator.Validate(orderStatusDto);

            _repository.Insert(new OrderStatus
            {
                Name = orderStatusDto.Name,
            });
        }

        public void DeleteOrderStatusById(Guid id)
        {
            var status = FindStatusInRepositoryByIdAndThrow(id);

            _repository.Delete(status);
        }

        public void UpdateOrderStatus(Guid id, OrderStatusRequestDto orderStatusDto)
        {
            _validator.Validate(orderStatusDto);
            var status = FindStatusInRepositoryByIdAndThrow(id);

            status.Name = orderStatusDto.Name;

            _repository.SaveChanges();
        }

        private OrderStatus FindStatusInRepositoryByIdAndThrow(Guid id)
        {
            var status = _repository.GetByID(id);

            if (status == null)
                throw new NotFoundException(nameof(OrderStatus), id);

            return status;
        }
    }
}
