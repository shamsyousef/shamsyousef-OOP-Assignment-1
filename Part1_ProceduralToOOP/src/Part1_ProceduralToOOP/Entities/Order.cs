using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP.Entities
{
    public class Order
    {
        public int Id { get; }
        public Customer Customer { get; }
        public bool IsPaid { get; private set; }

        private readonly List<OrderLine> _lines = new();

        public IReadOnlyList<OrderLine> Lines => _lines;

        public Order(int id, Customer customer)
        {
            Id = id;
            Customer = customer;
        }

        public void AddLine(Product product, int quantity)
        {
            if (IsPaid)
                throw new InvalidOperationException("Cannot modify a paid order.");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            if (!product.ReduceStock(quantity))
                throw new InvalidOperationException("Insufficient stock.");

            _lines.Add(new OrderLine(product, quantity));
        }

        public void MarkAsPaid()
        {
            IsPaid = true;
        }

        public decimal CalculateTotal()
        {
            decimal total = _lines.Sum(line => line.GetTotal());

            if (Customer.IsVip)
                total *= 0.9m;

            return total;
        }
    }
}
