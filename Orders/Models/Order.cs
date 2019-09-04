using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Models
{
    public class Order
    {
        public Order(string name, string description, DateTime created,
            int customerID, string id)
        {
            Name = name;
            Description = description;
            Created = created;
            CustomerID = customerID;
            Id = id;
            status = OrderStatuses.CREATED;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; private set; }
        public int CustomerID { get; set; }
        public string Id { get; private set; }

        public OrderStatuses status { get; set; }

        [Flags]
        public enum OrderStatuses
        {
            CREATED = 2,
            PROCESSING = 4,
            COMPLETED = 8,
            CANCELLED = 16,
        }
    }
}
