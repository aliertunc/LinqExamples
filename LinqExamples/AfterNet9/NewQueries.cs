using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples.AfterNet9
{
    public class NewQueries
    {
        #region CountByMethod

        public static void CountByMethod()
        {
            var fruits = new List<string> { "apple", "banana", "apple", "orange", "banana", "banana" };

            // CountBy metodu ile meyvelerin sıklığını hesaplıyoruz
            var fruitCounts = fruits.CountBy(fruit => fruit);

            foreach (var count in fruitCounts)
            {
                Console.WriteLine($"{count.Key}: {count.Value}");
            }
        }

        public static void BeforeCountByMethod()
        {
            var fruits = new List<string> { "apple", "banana", "apple", "orange", "banana", "banana" };

            // Klasik yöntemle meyvelerin sıklığını hesaplıyoruz
            var fruitCounts = new Dictionary<string, int>();

            foreach (var fruit in fruits)
            {
                if (fruitCounts.ContainsKey(fruit))
                {
                    fruitCounts[fruit]++;
                }
                else
                {
                    fruitCounts[fruit] = 1;
                }
            }

            foreach (var count in fruitCounts)
            {
                Console.WriteLine($"{count.Key}: {count.Value}");
            }
        }
        #endregion

        #region AggregateByMethod
        public static void AggregateByMethod()
        {
            var numbers = new List<(string Category, int Value)>
                {
                    ("A", 10),
                    ("B", 20),
                    ("A", 30),
                    ("C", 40)
                };

            // Her kategori için değerlerin toplamını hesapla, başlangıç değeri 100
            var aggregatedValues = numbers.AggregateBy(
                n => n.Category,
                100, // Başlangıç değeri
                (accumulator, item) => accumulator + item.Value);

            foreach (var item in aggregatedValues)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        public static void BeforeAggregateByMethod()
        {
            var numbers = new List<(string Category, int Value)>
        {
            ("A", 10),
            ("B", 20),
            ("A", 30),
            ("C", 40)
        };

            // GroupBy ile kategorileri gruplayıp, Aggregate ile başlangıç değeri 100 ile toplam hesaplıyoruz
            var aggregatedValues = numbers
                .GroupBy(n => n.Category)
                .Select(group => new
                {
                    Key = group.Key,
                    Value = group.Aggregate(100, (acc, item) => acc + item.Value)
                })
                .ToList();

            foreach (var item in aggregatedValues)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        #endregion

        #region Index
        public static void Index()
        {
            var fruits = new List<string> { "apple", "banana", "cherry", "date" };

            // Index metodu ile öğeleri ve indekslerini tuple olarak alıyoruz
            var indexedFruits = fruits.Index();

            // Sonuçları yazdırıyoruz
            foreach (var (index, item) in indexedFruits)
            {
                Console.WriteLine($"Index: {index}, Item: {item}");
            }
        }
        public static void BeforeIndex()
        {
            var fruits = new List<string> { "apple", "banana", "cherry", "date" };

            // İndeks ile her öğeyi almak için Select kullanıyoruz
            var indexedFruits = fruits.Select((item, index) => new { Index = index, Item = item }).ToList();

            // Sonuçları yazdırıyoruz
            foreach (var fruit in indexedFruits)
            {
                Console.WriteLine($"Index: {fruit.Index}, Item: {fruit.Item}");
            }
        }
        #endregion
    }
}
