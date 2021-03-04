using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase<int> db = new Database<int>(0, (seed) => seed + 1);
            IDaoFactory<int> factory = new DaoFactory<int>(db);
            SampleDataGenerator<int> generator = new SampleDataGenerator<int>(factory);
            generator.GenerateAll();
            IInterface<int> iFace = new ConsoleInterface<int>(factory);
            iFace.Begin();
        }
    }
}
