using Domain.Common.Repositories;
using Domain.Orders.Entities;

namespace Domain.Orders.Repositories;

public interface IOrderRepository : IRepository<Order>
{
}