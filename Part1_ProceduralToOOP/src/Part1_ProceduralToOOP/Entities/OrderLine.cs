using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP.Entities
{
    public class OrderLine
    {
        public Product Product { get; }
        public int Quantity { get; }

        public OrderLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal GetTotal()
        {
            return Product.Price * Quantity;
        }
    }
}
