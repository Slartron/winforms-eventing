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
        public void DoWork()
        {
            Thread.Sleep(_duration);
            
            System.Windows.Forms.MessageBox.Show($"{_name} finished!");
        }

        public async Task DoWorkAsync()
        {
            await Task.Delay(_duration);

            System.Windows.Forms.MessageBox.Show($"{_name} finished async!");
        }
    }
}
