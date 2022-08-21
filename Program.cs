namespace cSharp8
{
    public interface Building
    {
        public string Owner { get; set; }
    }
    public class House : Building
    {
        public string Owner { get; set; }
    }
    public class Apartment : Building
    {
        public string Owner { get; set; }
    }
    public abstract class Builder
    {
        public abstract Building BuildingFactory();
        public Building Result(string name)
        {
            var building = BuildingFactory();
            building.Owner = name;
            return building;
        }
    }
    public class HouseBuilder : Builder
    {
        public override Building BuildingFactory()
        {
            return new House();
        }
    }
    public class ApartmentBuilder : Builder
    {
        public override Building BuildingFactory()
        {
            return new Apartment();
        }
    }
    public class Facade
    {
        public Building Pick(string name, int a)
        {
            Builder pick;
            if (a == 1)
            {
                pick = new HouseBuilder();
                return pick.Result(name);
            }
            else
            {
                pick = new ApartmentBuilder();
                return pick.Result(name);
            }
        }
        public string Name(Building pick)
        {
            return pick.Owner;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            var prog = new Facade();
            Console.WriteLine("pls enter your name");
            string name = Console.ReadLine();
            Console.WriteLine($"pls enter the you choice: \n1. House \n2. Apartment");
            int choice = int.Parse(Console.ReadLine());
            Building yourBuilding = prog.Pick(name, choice);
            string owner = prog.Name(yourBuilding);
            Console.WriteLine(owner);
        }
    }
}
