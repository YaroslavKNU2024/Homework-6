using System;

namespace Ex._6
{
    public interface ITarget
    {
        string GetRequest();
    }

    // The Adaptee включає певний корисний функціонал але його інтерфейс несумісний з нашим кодом.
    class Adaptee
    {
        public string GetSpecificRequest() => "Some request";
    }

    //Адаптер робить інтерфейс суміісним із заданим інтерфейсом
    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee) {_adaptee = adaptee; }

        public string GetRequest() => $"This is '{_adaptee.GetSpecificRequest()}'";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is not compatible with client.");
            Console.WriteLine("However adapter makes it possible for client to call this method");

            Console.WriteLine(target.GetRequest());
        }
    }
}
