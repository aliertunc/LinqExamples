namespace LinqExamples
{
    // Yardımcı sınıflar
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public double TotalAmount => Products?.Sum(p => p.Price) ?? 0;
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
