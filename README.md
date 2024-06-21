
# Project 2 : Customer Management System using WPF

## Requirements

> ### Part 1: Setup the Data Model
>
> - [x] - 1. Create a New WPF Project
>   - [x] Open Visual Studio and create a new WPF App project named CustomerManagementSystemWPF.
> - [x] - 2. Define Data Classes
>   - [x] Create a Customer class with properties: CustomerId, Name, Email, and DateOfJoining.
>   - [x] Create an Order class with properties: OrderId, CustomerId, Amount, and OrderDate.
>
> ### Part 2: Implement Data Storage
>
> - [x] - 1. Initialize Collections
>   - [x] Use `ObservableCollection<Customer>` and `ObservableCollection<Order>` to store data in memory.
>   - [x] Populate these collections with sample data for testing.
>
> ### Part 3: Develop LINQ Queries
>
> - [x] - 1. Query Methods
>   - [x] ListCustomers: Use query syntax to list all customers.
>   - [x] FindOrdersByCustomer: Use fluent syntax to find all orders for a given customer ID, demonstrating deferred execution.
>   - [x] CalculateTotalSales: Implement a subquery to calculate the total sales for each customer.
>
> ### Part 4: WPF Interface
>
> - [x] - 1. Create the Main Window Layout
>   - [x] Design the main window to include sections for displaying customers, orders, and total sales.
>   - [x] Use controls such as ListView, DataGrid, TextBox, Button, and DatePicker to create the user interface.
> - [x] - 2. Implement Data Binding
>   - [x] Bind the `ObservableCollection<Customer>` and `ObservableCollection<Order>` to the UI controls for displaying data.
>   - [x] Implement two-way data binding where necessary to allow data entry.
> - [x] - 3. Create Interaction Logic
>   - [x] Implement event handlers for buttons to handle adding customers, adding orders, viewing customers, viewing orders, and calculating total sales.
>   - [x] Ensure that data operations are reflected in the UI dynamically.
>
> ### Sample Interface Functionality
>
> - [x] - 1. Add Customer
>   - [x] Fields: Name, Email, DateOfJoining
>   - [x] Button: Add Customer
> - [x] - 2. Add Order
>   - [x] Fields: CustomerId, Amount, OrderDate
>   - [x] Button: Add Order
> - [x] - 3. View Customers
>   - [x] Display all customers in a ListView or DataGrid.
> - [x] - 4. View Orders
>   - [x] Display all orders in a ListView or DataGrid.
> - [x] - 5. Calculate Total Sales
>   - [x] Display total sales for each customer in a TextBlock or Label.
