﻿using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;

namespace Orders.Schema
{
    public class OrderStatusesEnum: EnumerationGraphType
    {
        public OrderStatusesEnum()
        {
            Name = "OrderStatuses";
            AddValue("CREATED", "Order was created", 2);
            AddValue("PROCESSING", "Order is processing", 4);
            AddValue("COMPLETED", "Order is completed", 8);
            AddValue("CANCELLED", "Order was cancelled", 16);
            AddValue("CLOSED", "Order was closed", 32);

        }
    }
}
