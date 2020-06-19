using Moq;
using Sales.Domain.Model.Categories;
using Sales.Domain.Model.Orders;
using Sales.Domain.Model.Products;
using Sales.Domain.Services;
using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Sales.Domain.Tests
{
    public class OrderSpecs
    {
        [Fact]
        public void Create_order_item_success()
        {
            var orderService = new Mock<IOrderService>();
            orderService.Setup(x => x.HasAnyPendingOrders(2)).Returns(false);
            var id = 1;
            var customerId = 2;
            var category1 = new Category(1, "c1", null);
            var product1 = new Product(1, "p1", "d1", Color.Black, category1);
            var items = new List<OrderItem> { new OrderItem(product1, 3) };

            var fakeOrder = new Order(id, customerId, items, orderService.Object);

            fakeOrder.Should().NotBeNull();
        }

        [Fact]
        public void Cannot_create_order_with_same_items()
        {
            var orderService = new Mock<IOrderService>();
            orderService.Setup(x => x.HasAnyPendingOrders(2)).Returns(false);
            var id = 1;
            var customerId = 2;
            var category1 = new Category(1, "c1", null);
            var product1 = new Product(1, "p1", "d1", Color.Black, category1);
            var items = new List<OrderItem> { new OrderItem(product1, 3), new OrderItem(product1, 2) };

            Action action = () => new Order(id, customerId, items, orderService.Object);

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Cannot_create_order_when_have_any_pending_orders()
        {
            var orderService = new Mock<IOrderService>();
            orderService.Setup(x => x.HasAnyPendingOrders(2)).Returns(true);
            var id = 1;
            var customerId = 2;
            var category1 = new Category(1, "c1", null);
            var product1 = new Product(1, "p1", "d1", Color.Black, category1);
            var items = new List<OrderItem> { new OrderItem(product1, 3) };

            Action action = () => new Order(id, customerId, items, orderService.Object);

            action.Should().Throw<Exception>();
        }
    }
}
