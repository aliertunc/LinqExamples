namespace LinqExamples.BeforeNet9
{
    public class AdvancedQueries
    {
        public static void Run()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Apple", Price = 1.2, Category = "Fruit" },
                new Product { Id = 2, Name = "Banana", Price = 0.5, Category = "Fruit" },
                new Product { Id = 3, Name = "Carrot", Price = 0.7, Category = "Vegetable" },
                new Product { Id = 4, Name = "Broccoli", Price = 1.5, Category = "Vegetable" },
                new Product { Id = 5, Name = "Orange", Price = 1.0, Category = "Fruit" },
                new Product { Id = 6, Name = "Potato", Price = 0.3, Category = "Vegetable" }
            };

            Console.WriteLine("\nZor Seviye Örnekler:");

            // 8. Ürünlerin, fiyatlarının, isminin ve kategorisinin baş harfini içeren yeni bir nesne oluştur
            var transformedProducts = products
                .Select(p => new
                {
                    ProductName = p.Name,
                    Initial = p.Name.Substring(0, 1),
                    Category = p.Category,
                    FirstLetterOfCategory = p.Category.Substring(0, 1)
                });
            Console.WriteLine("Ürün bilgileri (isim, baş harf, kategori, kategori baş harfi):");
            foreach (var p in transformedProducts)
                Console.WriteLine($"Ad: {p.ProductName}, İsim Baş Harfi: {p.Initial}, Kategori: {p.Category}, Kategori Baş Harfi: {p.FirstLetterOfCategory}");

            // 9. Ürünlerin fiyatlarının toplamı ve ortalaması
            var priceSumAndAverage = new
            {
                Total = products.Sum(p => p.Price),
                Average = products.Average(p => p.Price)
            };
            Console.WriteLine($"\nToplam Fiyat: {priceSumAndAverage.Total}, Ortalama Fiyat: {priceSumAndAverage.Average}");

            // 10. 'Fruit' kategorisindeki ürünlerin, fiyatı 1'den küçük olanların toplam sayısını bul
            var countOfCheapFruits = products
                .Where(p => p.Category == "Fruit" && p.Price < 1)
                .Count();
            Console.WriteLine($"\n'Fruit' kategorisindeki fiyatı 1'den küçük olan ürünlerin sayısı: {countOfCheapFruits}");

            // 11. Obje İçinde Obje Listesi: Person ve Address
            var people = new List<Person>
            {
                new Person { Id = 1, Name = "John", Addresses = new List<Address> { new Address { City = "New York", Street = "5th Avenue" }, new Address { City = "Los Angeles", Street = "Sunset Blvd" } } },
                new Person { Id = 2, Name = "Sarah", Addresses = new List<Address> { new Address { City = "San Francisco", Street = "Market St" } } },
                new Person { Id = 3, Name = "Michael", Addresses = new List<Address> { new Address { City = "Chicago", Street = "Michigan Ave" }, new Address { City = "Houston", Street = "Main St" } } }
            };

            var peopleWithMultipleAddresses = from person in people
                                              where person.Addresses.Count > 1
                                              select person;
            Console.WriteLine("\nBirden fazla adresi olan kişiler:");
            foreach (var person in peopleWithMultipleAddresses)
            {
                Console.WriteLine($"{person.Name}:");
                foreach (var address in person.Addresses)
                    Console.WriteLine($" - {address.City}, {address.Street}");
            }

            // 12. Obje Listesinde İç İçe Gruplama ve Filtreleme: Order ve Product
            var orders = new List<Order>
            {
                new Order { Id = 1, Products = new List<Product> { new Product { Id = 1, Name = "Apple", Price = 1.2 }, new Product { Id = 2, Name = "Banana", Price = 0.5 } } },
                new Order { Id = 2, Products = new List<Product> { new Product { Id = 3, Name = "Carrot", Price = 0.7 }, new Product { Id = 4, Name = "Broccoli", Price = 1.5 } } },
                new Order { Id = 3, Products = new List<Product> { new Product { Id = 5, Name = "Orange", Price = 1.0 }, new Product { Id = 6, Name = "Potato", Price = 0.3 } } }
            };

            var orderTotals = orders.Select(order => new
            {
                OrderId = order.Id,
                TotalPrice = order.Products.Sum(p => p.Price)
            });
            Console.WriteLine("\nSiparişlerin toplam fiyatları:");
            foreach (var order in orderTotals)
                Console.WriteLine($"Sipariş {order.OrderId}: {order.TotalPrice}");

            // 13. Complex Filter: Employee ve Company
            var companies = new List<Company>
            {
                new Company { Name = "TechCorp", Employees = new List<Employee> { new Employee { Name = "Alice", Department = "IT", Salary = 60000 }, new Employee { Name = "Bob", Department = "HR", Salary = 50000 } } },
                new Company { Name = "FinCo", Employees = new List<Employee> { new Employee { Name = "Charlie", Department = "IT", Salary = 70000 }, new Employee { Name = "David", Department = "Finance", Salary = 80000 } } }
            };

            var itEmployeesWithHighSalary = companies
                .SelectMany(c => c.Employees)
                .Where(e => e.Department == "IT" && e.Salary > 65000);
            Console.WriteLine("\nIT departmanındaki yüksek maaşlı çalışanlar:");
            foreach (var employee in itEmployeesWithHighSalary)
                Console.WriteLine($"{employee.Name}, {employee.Salary}");

            // 14. Join ve GroupBy Kullanarak Karmaşık Sorgu: Author ve Book
            var authors = new List<Author>
            {
                new Author { Name = "J.K. Rowling", Books = new List<Book> { new Book { Title = "Harry Potter and the Philosopher's Stone" }, new Book { Title = "Harry Potter and the Chamber of Secrets" } } },
                new Author { Name = "George R.R. Martin", Books = new List<Book> { new Book { Title = "A Game of Thrones" }, new Book { Title = "A Clash of Kings" } } }
            };

            var authorBooks = authors.SelectMany(a => a.Books, (author, book) => new { author.Name, BookTitle = book.Title });
            Console.WriteLine("\nYazarlar ve kitapları:");
            foreach (var authorBook in authorBooks)
                Console.WriteLine($"{authorBook.Name}: {authorBook.BookTitle}");

            // 15. İç İçe Seçim ve Sıralama: Customer ve Order
            var customers = new List<Customer>
            {
                new Customer { 
                    Name = "John", 
                    Orders = new List<Order> { 
                        new Order { Id = 1, Products = new List<Product> { new Product { Id = 1, Name = "Apple", Price = 100.0 } } }, 
                        new Order { Id = 2, Products = new List<Product> { new Product { Id = 2, Name = "Banana", Price = 150.0 } } } 
                                            } 
                            },

                new Customer { 
                    Name = "Sarah", 
                    Orders = new List<Order> { 
                        new Order { Id = 3, Products = new List<Product> { new Product { Id = 3, Name = "Orange", Price = 200.0 } } }, 
                        new Order { Id = 4, Products = new List<Product> { new Product { Id = 4, Name = "Potato", Price = 50.0 } } } 
                    } 
                }
            };

            var highestOrders = customers.Select(c => new
            {
                CustomerName = c.Name,
                HighestOrder = c.Orders.OrderByDescending(o => o.TotalAmount).FirstOrDefault()
            });
            Console.WriteLine("\nHer müşterinin en pahalı siparişi:");
            foreach (var customer in highestOrders)
                Console.WriteLine($"{customer.CustomerName}: {customer.HighestOrder.TotalAmount}");


        }
    }
}
