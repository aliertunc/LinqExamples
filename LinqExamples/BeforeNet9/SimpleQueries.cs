namespace LinqExamples.BeforeNet9
{
    public class SimpleQueries
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

            Console.WriteLine("Basit Örnekler:");

            // 1. Fiyatı 1'den büyük olan ürünler
            var expensiveProducts = from p in products
                                    where p.Price > 1
                                    select p;
            Console.WriteLine("Fiyatı 1'den büyük olan ürünler:");
            foreach (var p in expensiveProducts)
                Console.WriteLine(p.Name);

            // 2. Ürün adlarını küçük harflerle listele
            var lowerCaseNames = products.Select(p => p.Name.ToLower());
            Console.WriteLine("\nÜrün adlarının küçük harflerle listesi:");
            foreach (var name in lowerCaseNames)
                Console.WriteLine(name);

            // 3. Kategorisi 'Fruit' olan ürünleri listele
            var fruits = products.Where(p => p.Category == "Fruit");
            Console.WriteLine("\nKategorisi 'Fruit' olan ürünler:");
            foreach (var p in fruits)
                Console.WriteLine(p.Name);
        }
    }
}
