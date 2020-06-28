using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace Settler
{
    class Program
    {

        static void Main(string[] args)
        {
            // TODO BEWARE handle injection attacks
            String path = ConfigurationManager.AppSettings.Get("Path");
            String title = ConfigurationManager.AppSettings.Get("Title");
            int delay = Int32.Parse(ConfigurationManager.AppSettings.Get("Delay"));
            int width = Int32.Parse(ConfigurationManager.AppSettings.Get("WindowWidth"));
            int height = Int32.Parse(ConfigurationManager.AppSettings.Get("WindowHeight"));
            int x = Int32.Parse(ConfigurationManager.AppSettings.Get("OffsetX"));
            int y = Int32.Parse(ConfigurationManager.AppSettings.Get("OffsetY"));

            const short SWP_NOZORDER = 0X4;
            const int SWP_SHOWWINDOW = 0x0040;

            Process.Start(path);
            Write("Start " + path);
            Write("Waiting " + delay + " milliseconds");
            Thread.Sleep(delay);
            IntPtr handle = Interop.HandleFromTitle(title);
            Write("Fetching handle " + handle);
            Interop.SetWindowPos(handle, 0, 0, 0, width, height, SWP_NOZORDER | SWP_SHOWWINDOW);
            Point pos = Interop.WindowOffsetPoint(handle, x, y);
            Write("Position click " + pos.X + "," + pos.Y);
            Interop.ClickOnPoint(handle, pos);
            Console.WriteLine("Should have started");
            Thread.Sleep(3000); // wait 3 sec before exiting
            //Console.ReadKey(); // uncomment if window should stay open
        }

        static void Write(string txt)
        {
            Console.WriteLine(txt);
        }
    }
}
