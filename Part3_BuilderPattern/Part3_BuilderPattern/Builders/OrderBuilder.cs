using Part3_BuilderPattern.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Part3_BuilderPattern.Builders
{
    public class OrderBuilder
    {
        private DateTime _orderDate;
        private string? _paymentMethod;
        private string? _currency;

        private decimal _subTotal;
        private decimal _discountAmount;
        private decimal _taxAmount;
        private decimal _totalAmount;

        public OrderBuilder SetOrderDate(DateTime orderDate)
        {
            _orderDate = orderDate;
            return this;
        }

        public OrderBuilder SetPaymentMethod(string paymentMethod)
        {
            _paymentMethod = paymentMethod;
            return this;
        }

        public OrderBuilder SetCurrency(string currency)
        {
            _currency = currency;
            return this;
        }

        public OrderBuilder SetSubTotal(decimal subTotal)
        {
            _subTotal = subTotal;
            return this;
        }

        public OrderBuilder SetDiscountAmount(decimal discountAmount)
        {
            _discountAmount = discountAmount;
            return this;
        }

        public OrderBuilder SetTaxAmount(decimal taxAmount)
        {
            _taxAmount = taxAmount;
            return this;
        }

        public OrderBuilder SetTotalAmount(decimal totalAmount)
        {
            _totalAmount = totalAmount;
            return this;
        }

        public OrderInfo Build()
        {
            if (_orderDate == default)
                throw new InvalidOperationException("Order date is required.");

            if (string.IsNullOrWhiteSpace(_paymentMethod))
                throw new InvalidOperationException("Payment method is required.");

            if (string.IsNullOrWhiteSpace(_currency))
                throw new InvalidOperationException("Currency is required.");

            return new OrderInfo(
                _orderDate,
                _paymentMethod,
                _currency,
                _subTotal,
                _discountAmount,
                _taxAmount,
                _totalAmount);
        }
    }
}