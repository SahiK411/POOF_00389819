using Examen.Classes;
using Examen.UserControls;
using System;
using System.Windows.Forms;

namespace Examen.DecoratorPattern
{
    public partial class MainView : UserControl, IDisplay
    {
        public User MainUser { get; set; }
        
        public MainView(User user)
        {
            InitializeComponent();
            MainUser = user;
            ControlRemoved += MainView_ControlRemoved;
        }

        public void ConstructView()
        {
            return;
        }

        private void Button1_LogOut(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea terminar su sesion?",
                    "Dialogo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var log = new LogInView();
                log.Dock = DockStyle.Fill;
                log.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                Parent.Controls.Add(log);
                Parent.Controls.Remove(this);
            }
        }

        public void MainView_ControlRemoved(object sender, ControlEventArgs e)
        {
            this.Dispose();
        }
    }
}
