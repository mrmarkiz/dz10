using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dz10
{
    internal class Task2
    {
        public static void Run()
        {
            Bag bag = new Bag();
            bag.ActionWithBagContent += bag.Add_Item;
            bag.Init();
            int choice;
            do
            {
                Console.WriteLine("Enter what to do(1-show bag, 2-add item, 0-exit):");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        bag.Show();
                        break;
                    case 2:
                        Console.Write("Enter item name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter item capacity: ");
                        double.TryParse(Console.ReadLine(), out double capacity);
                        Item item = new Item(name, capacity);
                        try
                        {
                            bag.Act(item);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"Error collapsed: {ex.Message}");
                        }
                        break;
                }
            } while (choice != 0);
        }
    }

    public class Bag
    {
        public string Color { get; set; }
        public string Mark { get; set; }
        public string Producer { get; set; }
        public string Material { get; set; }
        public double Weight { get; set; }
        public double Capacity { get; set; }
        public Item[] Content { get; set; }

        public delegate void ContentHandler(Item item);
        public event ContentHandler ActionWithBagContent;

        public Bag()
        {
            Color = string.Empty;
            Mark = string.Empty;
            Producer = string.Empty;
            Material = string.Empty;
            Weight = 0;
            Capacity = 0;
            Content = new Item[0];
        }

        public void Init()
        {
            Console.Write("Enter bag color: ");
            Color = Console.ReadLine();
            Console.Write("Enter bag mark: ");
            Mark = Console.ReadLine();
            Console.Write("Enter bag producer: ");
            Producer = Console.ReadLine();
            Console.Write("Enter bag material: ");
            Material = Console.ReadLine();
            Console.Write("Enter bag weight: ");
            double.TryParse(Console.ReadLine(), out double weight);
            Weight = weight;
            Console.Write("Enter bag capacity: ");
            double.TryParse(Console.ReadLine(), out double cap);
            Capacity = cap;
            Content = new Item[0];
        }

        public void Add_Item(Item item)
        {
            double free_space = Capacity;
            for (int i = 0; i < Content.Length; i++)
                free_space -= Content[i].Cap;
            if (free_space >= item.Cap)
                Content = Content.Append(item).ToArray();
            else
                throw new Exception("Not enought space in bag");
        }

        public void Act(Item item)
        {
            ActionWithBagContent?.Invoke(item);
        }

        public void Show()
        {
            Console.WriteLine($"Bag color: {Color}");
            Console.WriteLine($"Bag mark: {Mark}");
            Console.WriteLine($"Bag producer: {Producer}");
            Console.WriteLine($"Bag material: {Material}");
            Console.WriteLine($"Bag weight: {Weight}");
            Console.WriteLine($"Bag capacity: {Capacity}");
            Console.WriteLine("Bag content:");
            foreach(Item item in Content)
                Console.WriteLine(item);
            Console.WriteLine();
        }
    }
    public record Item
    {
        public string Name { get; set; }
        public double Cap { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Capacity: {Cap}";
        }
        public Item(string name, double cap)
        {
            Name = name;
            if (cap < 0)
                cap = 0;
            Cap = cap;
        }
    }
}
