using System;
using System.Windows.Forms;

namespace Examen_Parcial.DecoratorPattern
{
    public partial class MainView : UserControl, IDisplay
    {
        
        public MainView()
        {
            InitializeComponent();
        }

        public void ConstructView()
        {
            return;
        }

        private void Button1_LogOut(object sender, EventArgs e)
        {

        }
    }
}
