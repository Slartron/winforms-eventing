using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandlingEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public event Action Clicked;

        private void OnClicked()
        {
            //Clicked?.Invoke();

            var handler = Clicked;
            if (handler == null)
                return;

            Delegate[] delegates = handler.GetInvocationList();
            foreach (var delgato in delegates)
            {
                ((Action)delgato)();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OnClicked();
            }
            catch (Exception)
            {
                //nix
            }
        }



        public event Func<Task> ClickedAsync;

        private async Task OnClickedAsync()
        {
            await ClickedAsync?.Invoke();
        }


        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                await OnClickedAsync();
            }
            catch (Exception)
            {
                //nix
            }
        }
    }
}
