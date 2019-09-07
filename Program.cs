using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Officer_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int customers = 0;
            int timeInside = 0;
            int officers = 0;

            do
            {
                Console.Write("Please enter a valid number of customers: ");
            }
            while (int.TryParse(Console.ReadLine(), out customers) == false);

            do
            {
                Console.Write("Please enter a valid time spent inside in minutes (actually miliseconds): ");
            }
            while (int.TryParse(Console.ReadLine(), out timeInside) == false);

            do
            {
                Console.Write("Please enter a valid number of officers: ");
            }
            while (int.TryParse(Console.ReadLine(), out officers) == false);

            //Console.WriteLine("customers: " + customers);
            //Console.WriteLine("time inside: " + timeInside);
            //Console.WriteLine("officers: " + officers);

            QueueManagement Q = new QueueManagement(customers, timeInside, officers);
            Officer[] theOffice = new Officer[officers];
            Thread[] threads = new Thread[officers];

            for(int i = 0;i < officers;i++)
            {
                theOffice[i] = new Officer();
                threads[i] = new Thread(new ParameterizedThreadStart(theOffice[i].CallNextOne));
                threads[i].Start(i);
            }

            // Console.WriteLine("PRESS A KEY TO EXIT");  // Pauses program exit.
            // Console.ReadKey();                         // Pauses program exit.
        }
    }
}
