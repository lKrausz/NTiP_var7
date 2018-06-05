using System;
using System.Numerics;

using NTiP_var7;

//TODO: Этот проект уже можно удалить, в последующих лабораторных он уже не понадобится
namespace ConsoleLoader
    {
        class Program
        {
            static void Main()
            {
                //Тестовые параметры 
                double R = 12.1;
                Complex j = Complex.ImaginaryOne;
                double w = 1.7;
                double L = -11.4;
                double C = 10;

                Console.WriteLine("\t Welcome, user.\n");
                try
                {
                    Resistor resistor = new Resistor(R);
                    Console.WriteLine("Resistor complex impedances: " + resistor.ComplexImpedances(j, w) + "\n");
                }
            //TODO: УРА! Теперь ты правильно кидаешь и ловишь исключения :) Молодец, разобралась!
            catch (ValueLessThenNullException e)
                {
                    Console.WriteLine(e.Message + "\n");
                }

                try
                {
                Inductance inductance = new Inductance(L);
                Console.WriteLine("Inductance complex impedances: " + inductance.ComplexImpedances(j, w) + "\n");
                }
                catch (ValueLessThenNullException e)
                {
                    Console.WriteLine(e.Message + "\n");
                }

                try
                {
                    Capacitor capacitor = new Capacitor(C);
                    Console.WriteLine("Capacitor complex impedances: " + capacitor.ComplexImpedances(j, w) + "\n");
                }
                catch (ValueLessThenNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadKey();
            }
        }
    }

