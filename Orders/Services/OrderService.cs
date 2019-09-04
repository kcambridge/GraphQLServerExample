using System;
using System.Collections.Generic;
using System.Text;
using Orders.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Services
{
    public class OrderService : IOrderService
    {
        private IList<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>();
            _orders.Add(new Order("1000", "Pair of Shoes",
                DateTime.Now.AddDays(-1), 1, "0001"));
            _orders.Add(new Order("2000", "Pair of Jeans",
                DateTime.Now.AddDays(-2), 2, "0003"));
            _orders.Add(new Order("3000", "Bucket of Paint",
                DateTime.Now.AddDays(-10), 2, "0004"));
            _orders.Add(new Order("4000", "Wad of Singles",
                DateTime.Now.AddDays(0), 3, "0005"));
            _orders.Add(new Order("5000", "Something Illegal",
                DateTime.Now.AddDays(-16), 3, "0006"));
            _orders.Add(new Order("600", "Stuff",
                DateTime.Now.AddDays(-1), 3, "0007"));
        }
        public Task<Order> GetOrderByIDAsync(string id)
        {
            return Task.FromResult(_orders.Single(x => Equals(x.Id)));
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return Task.FromResult(_orders.AsEnumerable());
        }
    }

    public interface IOrderService
    {
        Task<Order> GetOrderByIDAsync(string id);
        Task<IEnumerable<Order>> GetOrdersAsync();
    }
}
