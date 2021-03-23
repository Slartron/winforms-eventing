using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace HandlingEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        #region Synchronous Eventing

        public event Action Clicked;

        private void RaiseClicked()
        {
            //In simple (single threaded) applications
            //Clicked?.Invoke();

            //In advanced (multi threaded) applications you shoud prefer this way
            var handler = Clicked;
            if (handler == null)
                return;

            Delegate[] delegates = handler.GetInvocationList();
            foreach (var delgato in delegates)
            {
                ((Action)delgato)();
            }
        }

        private void SyncButton_Click(object sender, EventArgs e)
        {
            try
            {
                RaiseClicked();
            }
            catch (Exception)
            {
                //handle exception
            }
        }

        #endregion


        #region Asynchronous Eventing

        public event Func<Task> ClickedAsync;

        private async Task RaiseClickedAsync()
        {
            // Asynchronous raising this way is a bad idea
            // because GUI thread continues after first await
            // This might not that what you want

            //await ClickedAsync?.Invoke();
            // or
            //await Task.WhenAll(ClickedAsync?.Invoke());


            // For full control you have to do it this way
            // Advantage: You COULD evaluate the return value,
            // but this might not be a good idea, since coupling
            // will be increased
            var handler = ClickedAsync;
            if (handler == null)
                return;

            Delegate[] delegates = handler.GetInvocationList();
            var tasks = new List<Task>();
            foreach (var delgato in delegates)
            {
                tasks.Add(((Func<Task>)delgato)());
            }

            // One possibility to await the tasks, Task.WhenAny is possiple too.
            await Task.WhenAll(tasks.ToArray());

            MessageBox.Show($"Events raised, done!");
        }


        private async void AsyncButton_Click(object sender, EventArgs e)
        {
            try
            {
                await RaiseClickedAsync();
            }
            catch (Exception)
            {
                //handle exception
            }
        }

        #endregion

    }
}
