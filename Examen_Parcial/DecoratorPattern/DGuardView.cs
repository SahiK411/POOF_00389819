using System;
using System.Drawing;
using System.Windows.Forms;

namespace Examen.DecoratorPattern
{
    public class DGuardView : ViewDecorator
    {
        public DGuardView(IDisplay ID) : base(ID)
        {
        }

        public override void ConstructView()
        {
            Button historyButton = new Button();
            historyButton.Dock = DockStyle.Fill;
            historyButton.Font = new Font("Microsoft YaHei", 14F);
            historyButton.Text = "Historial de Usuario";
            historyButton.TextAlign = ContentAlignment.MiddleCenter;
            historyButton.Enabled = true;

            Button registryButton = new Button();
            registryButton.Dock = DockStyle.Fill;
            registryButton.Font = new Font("Microsoft YaHei", 14F);
            registryButton.Text = "Registrar Entrada/Salida";
            registryButton.TextAlign = ContentAlignment.MiddleCenter;
            registryButton.Enabled = true;

            if (Display is MainView)
            {
                (Display as MainView).tableLayoutPanel1.Controls.Add(historyButton, 1, 3);
                (Display as MainView).tableLayoutPanel1.SetColumnSpan(historyButton, 1);
                (Display as MainView).tableLayoutPanel1.SetRowSpan(historyButton, 1);

                (Display as MainView).tableLayoutPanel1.Controls.Add(registryButton, 3, 3);
                (Display as MainView).tableLayoutPanel1.SetColumnSpan(registryButton, 1);
                (Display as MainView).tableLayoutPanel1.SetRowSpan(registryButton, 1);
            }
            else
            {
                throw new Exception("ConstructView Display Error");
            }
        }
    }
}
