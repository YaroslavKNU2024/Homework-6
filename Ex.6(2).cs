using System;

namespace Ex._6._2
{
    class Program
    {
        abstract class Developer
        {
            public string Name { get; set; }

            public Developer(string n)
            {
                Name = n;
            }
            // фабричний метод
            abstract public House Create();
        }
        // Будує панельні будинки
        class PanelDeveloper : Developer
        {
            public PanelDeveloper(string n) : base(n) { }

            public override House Create() => new PanelHouse();
        }
        // строит деревянные дома
        class WoodDeveloper : Developer
        {
            public WoodDeveloper(string n) : base(n) { }

            public override House Create() => new WoodHouse();
        }

        abstract class House
        { }

        class PanelHouse : House
        {
            public PanelHouse()
            {
                Console.WriteLine("Panel house");
            }
        }
        class WoodHouse : House
        {
            public WoodHouse()
            {
                Console.WriteLine("Wooden house built");
            }
        }
        static void Main(string[] args)
        {
            Developer dev = new PanelDeveloper("Panel house building company");
            House house2 = dev.Create();

            Developer dev2 = new WoodDeveloper("Private wooden house building company");
            House house = dev2.Create();

            Console.ReadLine();
        }
    }
}
