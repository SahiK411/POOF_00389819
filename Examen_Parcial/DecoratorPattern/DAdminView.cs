using System;
using System.Drawing;
using System.Windows.Forms;

namespace Examen_Parcial.DecoratorPattern
{
    public class DAdminView : ViewDecorator
    {
        public DAdminView(IDisplay ID) : base(ID)
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

            Button manageButton = new Button();
            manageButton.Dock = DockStyle.Fill;
            manageButton.Font = new Font("Microsoft YaHei", 14F);
            manageButton.Text = "Manejar Usuarios";
            manageButton.TextAlign = ContentAlignment.MiddleCenter;
            manageButton.Enabled = true;

            Button summaryButton = new Button();
            summaryButton.Dock = DockStyle.Fill;
            summaryButton.Font = new Font("Microsoft YaHei", 14F);
            summaryButton.Text = "Ver Resumenes";
            summaryButton.TextAlign = ContentAlignment.MiddleCenter;
            summaryButton.Enabled = true;

            if (display is MainView)
            {
                (display as MainView).tableLayoutPanel1.Controls.Add(historyButton, 1, 2);
                (display as MainView).tableLayoutPanel1.SetColumnSpan(historyButton, 1);
                (display as MainView).tableLayoutPanel1.SetRowSpan(historyButton, 1);

                (display as MainView).tableLayoutPanel1.Controls.Add(registryButton, 3, 2);
                (display as MainView).tableLayoutPanel1.SetColumnSpan(registryButton, 1);
                (display as MainView).tableLayoutPanel1.SetRowSpan(registryButton, 1);

                (display as MainView).tableLayoutPanel1.Controls.Add(manageButton, 1, 4);
                (display as MainView).tableLayoutPanel1.SetColumnSpan(manageButton, 1);
                (display as MainView).tableLayoutPanel1.SetRowSpan(manageButton, 1);

                (display as MainView).tableLayoutPanel1.Controls.Add(summaryButton, 3, 4);
                (display as MainView).tableLayoutPanel1.SetColumnSpan(summaryButton, 1);
                (display as MainView).tableLayoutPanel1.SetRowSpan(summaryButton, 1);
            }
            else
            {
                throw new Exception("ConstructView Display Error");
            }
        }
    }
}
