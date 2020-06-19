namespace Sales.Domain.Model.Orders
{
    public enum OrderState
    {
        Placed = 1,
        Reserved = 2,
        Paid = 3,
        Shipped = 4,
        Received = 5
    }
}