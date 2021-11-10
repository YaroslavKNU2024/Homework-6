using System;

namespace Ex._4
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ChristmasTree c = new ChristmasTree();
            Lights d1 = new Lights();
            ChristmasToys d2 = new ChristmasToys();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Component
    {
        public bool LightsAreOn;
        public bool LightsAreTurnedOn;
        public bool ToysAreOn;
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class ChristmasTree : Component
    {
        public bool ToysAreOn = false;
        public bool LightsAreOn = false;
        public bool LightsAreTurnedOn = false;
        public override void Operation()
        {
            Console.WriteLine("Christmas tree");
            Console.WriteLine("Lights put on: " + LightsAreOn.ToString());
            Console.WriteLine("Lights turned on: " + LightsAreTurnedOn.ToString());
            Console.WriteLine("Put on: " + ToysAreOn.ToString() + "\n");
        }
    }
    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class Lights: Decorator
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "New State";
            Console.WriteLine("Added lights");
            AddedBehaviour();
        }
        public void AddedBehaviour()
        {
            LightsAreOn = true;
            LightsAreTurnedOn = true;
            Console.WriteLine("Lights: ");
            Console.WriteLine("Put on: " + LightsAreOn.ToString());
            Console.WriteLine("Turned on: " + LightsAreTurnedOn.ToString() + "\n");
        }
    }

    // "ConcreteDecoratorB" 
    class ChristmasToys : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            ToysAreOn = true;
            Console.WriteLine("Added toys on a tree");
            AddedBehavior();

        }
        void AddedBehavior()
        {
            Console.WriteLine("Toys are on a tree: " + ToysAreOn.ToString());
        }
    }
}
