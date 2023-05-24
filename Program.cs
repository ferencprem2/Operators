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
            Operations.Where(x => new string[6]{"mod", "/", "div", "-", "*", "+"}.Contains(x.Operand1)).GroupBy(x => x.Operand1).ToList().ForEach(x => Console.WriteLine($"\t {x.Key} -> {x.Count()}"));

            //6.feladat:




        }

        static void ParseTxtContent()
        {
            Operations = File.ReadAllLines("kifejezesek.txt").Select(x => new Operands(x)).ToList();

        }

        static string OperatorHandler(string term)
        {
            int firstNumber = Convert.ToInt32(term.Split("")[0]);
            string currentOperator = term.Split("")[1];
            int secondNumber = Convert.ToInt32(term.Split("")[2]);
            string[] operatorArray = {"mod", "/", "div", "-", "*", "+" };
            if (operatorArray.Contains(currentOperator))
            {
                    switch (currentOperator)
                    {
                        case "+":
                            return $"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}";
                        case "-":
                            return $"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}";
                        case "*":
                            return $"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}";
                        case "/":
                            return $"{firstNumber} / {secondNumber} = {Convert.ToDouble(firstNumber) / Convert.ToDouble(secondNumber)}";
                        case "mod":
                            return $"{firstNumber} div {secondNumber} = {firstNumber / secondNumber}";
                        case "div":
                            return $"{firstNumber} mod {secondNumber} = {firstNumber % secondNumber}";
                    }
            }
            else if (!operatorArray.Contains(currentOperator))
            {
                return "Hibás operátor!";
            }
            else
            {
                return "Egyéb hiba!";
            }

            return "";
        }
    }
}