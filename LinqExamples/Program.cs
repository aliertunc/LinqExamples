using LinqExamples.AfterNet9;
using LinqExamples.BeforeNet9;

namespace LinqExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Net9 öncesi kullanılan bazı linq örnekleri
            #region BeforeNet9

            // Basit örnekler
            SimpleQueries.Run();

            // Orta seviye örnekler
            MediumQueries.Run();

            // Zor seviye örnekler
            AdvancedQueries.Run();
            #endregion

            //Net 9 ile gelen yeni metotlar ve öncesinde nasıl kullanıldığı
            #region AfterNet9
            Console.WriteLine("\nNet 9 Examples");
            NewQueries.CountByMethod();
            NewQueries.BeforeCountByMethod();
            Console.WriteLine("\n");

            NewQueries.AggregateByMethod();
            NewQueries.BeforeAggregateByMethod();
            Console.WriteLine("\n");

            NewQueries.Index();
            NewQueries.BeforeIndex();
            Console.WriteLine("\n");

            #endregion

            Console.ReadLine();
        }
    }
}
