\# Critique of the Procedural Order System



\## 1. Global State



The program stores customers, products, and orders in global variables and arrays.



For example, customer and product data are stored in global arrays such as `customerIds`, `customerNames`, `productIds`, and `productPrices`.



This is a problem because any function can directly modify the shared state. As the system grows, it becomes harder to control where and how the data is changed.



A better design would keep the data inside objects such as `Customer`, `Product`, and `Order`.



\## 2. Parallel Arrays



The data for one entity is split across multiple arrays. For example, a customer is represented using `customerIds`, `customerNames`, `customerEmails`, `customerCities`, and `customerIsVip`.



The same index is used to connect the values belonging to the same customer.



This makes the code harder to maintain because all arrays must stay synchronized. An indexing mistake could cause data from different customers to become incorrectly associated.



Using a `Customer` class would keep all customer-related data together.



\## 3. Fixed-Size Arrays



The program uses fixed limits such as `MAX\_CUSTOMERS`, `MAX\_PRODUCTS`, `MAX\_ORDERS`, and `MAX\_LINES\_PER\_ORDER`.



This means the system can only store a fixed number of records. For example, once the customer limit is reached, new customers cannot be added.



This makes the system less flexible and ties the business logic to fixed implementation limits.



\## 4. Relationships Represented by Indexes



Orders refer to customers using indexes such as `orderCustomerIndexes`, and order lines refer to products using `lineProductIndexes`.



This means the program has to repeatedly search for indexes and then use those indexes to access the actual data.



This makes relationships between the domain entities less clear and increases the risk of invalid references.



In an object-oriented design, an `Order` can have a reference to a `Customer`, and an `OrderLine` can have a reference to a `Product`.



\## 5. Business Rules Are Scattered Across Functions



Business rules are implemented inside procedural functions instead of being owned by the objects they belong to.



For example, `addLineToOrder()` checks whether the order is paid, whether the quantity is positive, and whether enough stock is available.



The VIP discount is implemented separately inside `calculateOrderTotal()`.



As the system grows, more rules could become spread across different functions, making the code harder to maintain.



An object-oriented design can place behavior and rules inside the classes responsible for the related data.



\## 6. Limited Encapsulation



The program does not have classes that protect their own state. The data is stored in global arrays and can be modified directly by functions.



For example, the payment state is stored as a boolean in `orderIsPaid`, and `markOrderPaid()` directly changes that value.



This makes it difficult to guarantee that an object is always in a valid state.



With OOP, an `Order` class could expose a method such as `MarkAsPaid()` and control how its payment state changes.



\## 7. Responsibilities Are Mixed



The functions handle both business operations and direct manipulation of the underlying data structures.



For example, functions such as `addCustomer()`, `createOrder()`, and `addLineToOrder()` directly manage the arrays and also perform validation.



This makes the code more dependent on its implementation details.



Separating responsibilities into classes such as `Customer`, `Product`, `Order`, and `OrderLine` would make the design easier to understand and maintain.

