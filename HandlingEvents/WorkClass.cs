using System;
using System.Threading;
using System.Threading.Tasks;

namespace HandlingEvents
{
    class WorkClass
    {
        private int _duration;
        private string _name;
        public WorkClass(int duration, string name)
        {
            _duration = duration;
            _name = name;
        }

        public void SimpleEventHandler()
        {
            // try-catch block is good practice but not mandatory,
            // if event raising implements proper exception handling
            try
            {
                Thread.Sleep(_duration);
                // throw new Exception("harhar");

                System.Windows.Forms.MessageBox.Show($"{_name} finished!");
            }
            catch (Exception)
            {
                // handle exception
            }
        }

        public async void AsyncVoidEventHandler()
        {
            // try-catch block is mandatory in async void event handlers
            // or your application will crash if an exception is raised
            try
            {
                // Exception before await w/o try-catch => other handlers would not execute if this exception is thrown
                //throw new Exception("harhar");
                await Task.Delay(_duration);

                // Exception after await w/o try-catch => KAABOOOOM application crashes
                //throw new Exception("harhar");

                System.Windows.Forms.MessageBox.Show($"{_name} finished!");
            }
            catch (Exception)
            {
                // handle exception
            }
        }

        public async Task AsyncTaskEventHandler()
        {
            // try catch block is not mandatory but would be good practice

            // return type Task ensures proper exception handling, if 
            // event raising has proper exception handling

            //throw new Exception("harhar");    // other handlers would not execute if this exception is thrown
            await Task.Delay(_duration);
            //throw new Exception("harhar");    // even this exception would be properly routed to the GUI thread

            System.Windows.Forms.MessageBox.Show($"{_name} finished async!");
        }
    }
}
