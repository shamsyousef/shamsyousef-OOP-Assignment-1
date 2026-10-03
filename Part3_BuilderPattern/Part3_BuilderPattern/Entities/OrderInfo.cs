using System;
using System.Collections.Generic;
using System.Text;

namespace Part3_BuilderPattern.Entities
{
    public class OrderInfo
    {
        public DateTime OrderDate { get; }
        public string PaymentMethod { get; }
        public string Currency { get; }

        public decimal SubTotal { get; }
        public decimal DiscountAmount { get; }
        public decimal TaxAmount { get; }
        public decimal TotalAmount { get; }

        public OrderInfo(
            DateTime orderDate,
            string paymentMethod,
            string currency,
            decimal subTotal,
            decimal discountAmount,
            decimal taxAmount,
            decimal totalAmount)
        {
            OrderDate = orderDate;
            PaymentMethod = paymentMethod;
            Currency = currency;
            SubTotal = subTotal;
            DiscountAmount = discountAmount;
            TaxAmount = taxAmount;
            TotalAmount = totalAmount;
        }
    }
}
