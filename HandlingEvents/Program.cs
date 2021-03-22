using System;
using System.Collections.Generic;
using System.Linq;
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
            
            var form = new Form1();
            var worker1 = new WorkClass(2000, "worker1");
            var worker2 = new WorkClass(2500, "worker2");
            
            form.Clicked += worker1.DoWork;
            //form.Clicked += worker2.DoWork;


            form.ClickedAsync += worker1.DoWorkAsync;
            form.ClickedAsync += worker2.DoWorkAsync;

            Application.Run(form);
        }
    }
}
