using Part1_ProceduralToOOP.Entities;
var customer = new Customer(
    1,
    "Shams",
    "shams@example.com",
    "Cairo",
    true
);

var laptop = new Product(
    1,
    "Laptop",
    30000m,
    10
);

var mouse = new Product(
    2,
    "Mouse",
    500m,
    20
);

var order = new Order(1, customer);

order.AddLine(laptop, 2);
order.AddLine(mouse, 1);
var secondOrder = new Order(2, customer);

secondOrder.AddLine(mouse, 2);

var orders = new List<Order>
{
    order,
    secondOrder
};
decimal orderTotal = order.CalculateTotal();
order.MarkAsPaid();
decimal totalSales = orders.Sum(o => o.CalculateTotal());




Console.WriteLine($"Order Total: {orderTotal}");
Console.WriteLine($"Order Paid: {order.IsPaid}");
Console.WriteLine($"Laptop Stock: {laptop.Stock}");
Console.WriteLine($"Mouse Stock: {mouse.Stock}");
Console.WriteLine($"Total Sales: {totalSales}");