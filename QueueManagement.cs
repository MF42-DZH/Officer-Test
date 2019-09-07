using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Officer_Project
{
    // Consider using a struct with public non-static members with { get; private set; } accessors
    // (or { get; set; }) in the case of _customers instead for holding values without much methods.
    // Assignments and modifications to fields are faster than if using class.
    // See: https://www.c-sharpcorner.com/blogs/difference-between-struct-and-class-in-c-sharp
    class QueueManagement
    {
        private static int _customers;
        public static int Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                //_mutex.WaitOne();
                _customers = value;
                //_mutex.ReleaseMutex();
            }
        }

        // Changed access level to public so Officer instances can access.
        // Added readonly so that Officer instances cannot replace this with a new instance.
        public static readonly Mutex _mutex = new Mutex();  // Using this instead of an individial Mutex in each Officer

        public static int _timeInside;
        private int _officers;
        public static Random _random = new Random();

        public QueueManagement(int customers, int timeInside, int officers)
        {
            _customers = customers;
            _timeInside = timeInside;
            _officers = officers;
        }

    }
}
