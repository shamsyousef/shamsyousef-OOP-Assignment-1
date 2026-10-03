using Part3_BuilderPattern.Builders;

var billingAddress = new AddressBuilder()
    .SetStreet("Street 1")
    .SetCity("Cairo")
    .SetState("Cairo")
    .SetZipCode("12345")
    .SetCountry("Egypt")
    .Build();

var shippingAddress = new AddressBuilder()
    .SetStreet("Street 2")
    .SetCity("Giza")
    .SetState("Giza")
    .SetZipCode("54321")
    .SetCountry("Egypt")
    .Build();

var orderInfo = new OrderBuilder()
    .SetOrderDate(DateTime.Now)
    .SetPaymentMethod("Credit Card")
    .SetCurrency("EGP")
    .SetSubTotal(5000m)
    .SetDiscountAmount(200m)
    .SetTaxAmount(700m)
    .SetTotalAmount(5500m)
    .Build();

var invoice = new InvoiceBuilder()
    .SetInvoiceId(1)
    .SetCustomerName("Shams Ashraf")
    .SetCustomerEmail("shams@example.com")
    .SetCustomerPhone("01012370079")
    .SetBillingAddress(billingAddress)
    .SetShippingAddress(shippingAddress)
    .SetOrderInfo(orderInfo)
    .Build();

Console.WriteLine($"Invoice: {invoice.InvoiceId}");
Console.WriteLine($"Customer: {invoice.CustomerName}");
Console.WriteLine($"Billing City: {invoice.BillingAddress.City}");
Console.WriteLine($"Shipping City: {invoice.ShippingAddress.City}");
Console.WriteLine($"Payment: {invoice.OrderInfo.PaymentMethod}");
Console.WriteLine($"Total: {invoice.OrderInfo.TotalAmount}");