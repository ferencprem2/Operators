using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    internal class Operands
    {
        private int FirstNumber;
        private string Operand;
        private int LastNumber;

        public Operands(string csvline) 
        {
            var lines = csvline.Split(" ");

            FirstNumber = Convert.ToInt32(lines[0]);
            Operand = lines[1]; 
            LastNumber = Convert.ToInt32(lines[2]);
        
        }   

        public Operands(int firstNumber, string operand, int lastNumber) 
        {
            this.FirstNumber = firstNumber;
            this.Operand = operand;
            this.LastNumber = lastNumber;
        }

        public int FirstNumber1 { get => FirstNumber; set => FirstNumber = value; }
        public string Operand1 { get => Operand; set => Operand = value; }
        public int LastNumber1 { get => LastNumber; set => LastNumber = value; }
    }
}
