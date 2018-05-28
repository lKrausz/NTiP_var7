using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTiP_var7;


namespace ConsoleLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t Welcome, user.\n");
            IPassiveElement resistor = new Resistor();
            Console.WriteLine("Resistor complex impedances: " + resistor.ComplexImpedances() + "\n");
            IPassiveElement inductance = new Inductance();
            Console.WriteLine("Inductance complex impedances: " + inductance.ComplexImpedances() + "\n");
            IPassiveElement capacitor = new Capacitor();
            Console.WriteLine("Capacitor complex impedances: " + capacitor.ComplexImpedances() + "\n");
            Console.ReadKey();
        }
    }
}
