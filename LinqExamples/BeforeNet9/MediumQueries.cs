namespace LinqExamples.BeforeNet9
{
    public class MediumQueries
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

            Console.WriteLine("\nOrta Seviye Örnekler:");

            // 4. Fiyatı en pahalı 2 ürünü bul
            var top2Expensive = products.OrderByDescending(p => p.Price).Take(2);
            Console.WriteLine("Fiyatı en pahalı 2 ürün:");
            foreach (var p in top2Expensive)
                Console.WriteLine(p.Name);

            // 5. Kategorilere göre grupla ve her grubun ortalama fiyatını hesapla
            var averagePriceByCategory = products
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, AveragePrice = g.Average(p => p.Price) });

            Console.WriteLine("\nKategoriye göre ortalama fiyatlar:");
            foreach (var g in averagePriceByCategory)
                Console.WriteLine($"Kategori: {g.Category}, Ortalama Fiyat: {g.AveragePrice}");

            // 6. Fiyatı 1'den büyük, ancak adı 'Banana' olmayan ürünleri listele
            var filteredProducts = products
                .Where(p => p.Price > 1 && p.Name != "Banana");
            Console.WriteLine("\nFiyatı 1'den büyük ancak adı 'Banana' olmayan ürünler:");
            foreach (var p in filteredProducts)
                Console.WriteLine(p.Name);

            // 7. Tüm ürünlerin isimlerini alfabetik sıraya göre listele
            var sortedNames = products.OrderBy(p => p.Name).Select(p => p.Name);
            Console.WriteLine("\nÜrün isimlerinin alfabetik sıralaması:");
            foreach (var name in sortedNames)
                Console.WriteLine(name);
        }
    }
}
