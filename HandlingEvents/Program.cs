using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandlingEvents
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Just to examine the possibilities to catch events on these last lines of defense
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationOnThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;



            var form = new Form1();
            var worker1 = new WorkClass(2000, "worker1");
            var worker2 = new WorkClass(5000, "worker2");
            
            //form.Clicked += worker1.SimpleEventHandler;
            //form.Clicked += worker2.SimpleEventHandler;

            form.Clicked += worker1.AsyncVoidEventHandler;
            form.Clicked += worker2.AsyncVoidEventHandler;

            form.ClickedAsync += worker1.AsyncTaskEventHandler;
            form.ClickedAsync += worker2.AsyncTaskEventHandler;


            Application.Run(form);
        }

        private static void CurrentDomainOnUnhandledException(
            object sender,
            UnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"Caught exception on AppDomain level!");
        }

        private static void ApplicationOnThreadException(
            object sender,
            ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"Caught exception on Application level!");
        }
    }
}
