using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Operators
{
    internal class Program
    {
        static public List<Operands> Operations = new();
        static void Main(string[] args)
        {
            ParseTxtContent();

            //2.fealdat
            Console.WriteLine($"2. fealdat: {Operations.Select(x => x.Operand1).Count()}");

            //3.feladat:
            Console.WriteLine($"3. feladat: {Operations.Where(x => x.Operand1 == "mod").Count()}");

            //4.feladat:
            var isInList = Operations.Any(x => x.FirstNumber1 % 10 == 0 && x.LastNumber1 % 10 == 0) ? "Van ilyen kifejezés!" : "Nincs ilyen kifejezés";
            Console.WriteLine($"4. fealdat: {isInList}");

            //5.feladat:
            Console.WriteLine("5. feladat: Statisztika");
            Operations.GroupBy(x => x.Operand1).Select(y => new { op = y.Key, count = y.Count()}).OrderBy(x => x.op).ToList().ForEach(x => Console.WriteLine($"{x.op} -> {x.count}"));
        }

        static void ParseTxtContent()
        {
            Operations = File.ReadAllLines("kifejezesek.txt").Select(x => new Operands(x)).ToList();

        }
    }
}