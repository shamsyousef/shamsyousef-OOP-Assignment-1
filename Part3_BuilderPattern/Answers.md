# Task 3 - Builder Pattern

## 3.1 Why Is a 20-Parameter Constructor a Problem?

A constructor with around 20 parameters is difficult to use and maintain.

### 1. Poor readability at the call site

When calling a constructor with many parameters, it is difficult to understand what each argument represents.

For example:

```csharp
new Invoice(
    1,
    "Shams Ashraf",
    "shams@example.com",
    "01012345678",
    "Street 1",
    "Cairo",
    ...
);
```

The caller has to remember the exact order of all parameters.

### 2. Risk of passing values in the wrong order

This becomes dangerous when several parameters have the same type, such as multiple `string` or `decimal` values.

The code can compile even if two values are swapped.

For example, a billing city could accidentally be passed where the billing state is expected.

### 3. Optional properties make the constructor harder to use

If a new optional property is added, the constructor may become even longer.

The caller may have to pass values that are not important for every invoice, making the API harder to understand and maintain.

### Is the problem only that the constructor is too long?

No. The deeper problem is a design issue.

The `Invoice` contains several groups of information with different responsibilities:

- Customer information
- Billing address
- Shipping address
- Order information
- Payment information

Putting all of these details into one large constructor makes the class harder to understand, validate, and maintain.

The problem is therefore not only the number of parameters. It is also that too many different concerns are being handled together.

---

## 3.2 Builder Pattern

The Builder Pattern provides a more readable way to construct the `Invoice`.

Instead of passing all properties through one large constructor, the caller can set properties using meaningful methods:

```csharp
var invoice = new InvoiceBuilder()
    .SetInvoiceId(1)
    .SetCustomerName("Shams Ashraf")
    .SetCustomerEmail("shams@example.com")
    .SetBillingAddress(...)
    .SetShippingAddress(...)
    .SetOrderInfo(...)
    .Build();
```

This makes the construction process easier to read and reduces the risk of confusing parameters with the same type.

The `Build()` method also validates mandatory properties before creating the final object.

---

## 3.3 Refactoring into Composed Builders

The first Builder implementation still had many responsibilities because one `InvoiceBuilder` handled customer information, both addresses, and order information.

The design was therefore refactored into smaller builders:

```text
InvoiceBuilder
├── AddressBuilder
├── AddressBuilder
└── OrderBuilder
```

The same `AddressBuilder` is used for both billing and shipping addresses.

### Single Responsibility

Each builder now has one main responsibility:

- `AddressBuilder` is responsible for creating and validating an `Address`.
- `OrderBuilder` is responsible for creating and validating `OrderInfo`.
- `InvoiceBuilder` is responsible for assembling the complete `Invoice`.

This makes each class easier to understand and maintain.

### Independent Validation

`AddressBuilder` validates the address fields itself.

For example, it makes sure that Street, City, State, ZipCode, and Country are provided.

`InvoiceBuilder` does not need to know the validation details of every address field.

The same applies to `OrderBuilder`, which validates the order and payment information.

This keeps validation close to the data it belongs to.

### Reuse

`AddressBuilder` can be reused for both billing and shipping addresses.

Without this reusable builder, the same address-building and validation logic would have to be duplicated for both addresses.

For example:

```csharp
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
```

The same builder is used with different values.

### Readability at the Call Site

The composed version makes the purpose of each part clearer.

Instead of one large builder containing all invoice details, the caller first creates the required components and then composes them:

```csharp
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
    .SetCustomerPhone("01012345678")
    .SetBillingAddress(billingAddress)
    .SetShippingAddress(shippingAddress)
    .SetOrderInfo(orderInfo)
    .Build();
```

Each part of the construction has a clear purpose, and the final `InvoiceBuilder` focuses on composing the complete invoice rather than managing every individual property.

## Conclusion

The Builder Pattern improves the construction of complex objects by making the creation process more readable and controlled.

The composed Builder approach goes further by separating responsibilities into smaller reusable builders. This improves maintainability, validation, reuse, and readability.