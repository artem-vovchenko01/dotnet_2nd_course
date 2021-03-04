using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase<int> db = new Database<int>(0, (seed) => seed + 1);
            IDaoFactory<int> factory = new DaoFactory(db);
            SampleDataGenerator generator = new SampleDataGenerator(factory);
            generator.GenerateAll();
            IInterface<int> iFace = new ConsoleInterface(factory);
            iFace.Begin();
        }
    }
}
