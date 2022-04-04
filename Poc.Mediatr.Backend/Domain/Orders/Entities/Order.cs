using Domain.Common.Entities;
using Domain.Orders.Enums;

namespace Domain.Orders.Entities;

public class Order : RootEntity
{
    private Order()
    {
    }

    public Order(Guid id, Guid customerId) : base(id)
    {
        CustomerId = customerId;
        Status = OrderStatus.AwaitingPayment;
    }

    public Guid CustomerId { get; }
    public OrderStatus Status { get; }
}