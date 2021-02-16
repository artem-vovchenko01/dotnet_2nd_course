using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            DaoFactory factory = new DaoFactory(db);
            SampleDataGenerator generator = new SampleDataGenerator(factory);
            generator.GenerateAll();
            ConsoleInterface iFace = new ConsoleInterface(factory);
            iFace.Begin();
        }
    }
}
