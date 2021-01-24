using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class Timer
    {
        static System.Timers.Timer t;

        public static void Begining()
        {
            t = new System.Timers.Timer();
            t.AutoReset = false;
            t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
            t.Interval = GetInterval();
            t.Start();
           // Console.ReadLine();
        }
        public static void Stop()
        {
            t.Stop();
        }

        static double GetInterval()
        {
            DateTime now = DateTime.Now;
            return ((60 - now.Second) * 1000 - now.Millisecond);
        }

        static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("o"));
            t.Interval = GetInterval();
            t.Start();
        }
    }
}
