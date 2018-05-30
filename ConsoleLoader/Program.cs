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
                //Тестовые параметры 
                double R = 12.1;
                double j = 4.2;
                double w = 1.7;
                double L = 11.4;
                double C = -2;

                Console.WriteLine("\t Welcome, user.\n");

                Resistor resistor = new Resistor(R);
                Console.WriteLine("Resistor complex impedances: " + resistor.ComplexImpedances() + "\n");

                Inductance inductance = new Inductance(j, w, L);
                Console.WriteLine("Inductance complex impedances: " + inductance.ComplexImpedances() + "\n");

                Capacitor capacitor = new Capacitor(j, w, C);
                Console.WriteLine("Capacitor complex impedances: " + capacitor.ComplexImpedances() + "\n");

                Console.ReadKey();
            }
        }
    }

