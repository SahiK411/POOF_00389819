using System;
using System.Drawing;
using System.Windows.Forms;

namespace Examen_Parcial.DecoratorPattern
{
    public class DUserView : ViewDecorator
    {
        public DUserView(IDisplay ID) : base(ID)
        {
        }

        public override void ConstructView()
        {
            Button historyButton = new Button();
            historyButton.Dock = DockStyle.Fill;
            historyButton.Font = new Font("Microsoft YaHei", 24F);
            historyButton.Text = "Historial de Usuario";
            historyButton.TextAlign = ContentAlignment.MiddleCenter;
            historyButton.Enabled = true;

            if (display is MainView)
            {
                (display as MainView).tableLayoutPanel1.Controls.Add(historyButton, 1, 3);
                (display as MainView).tableLayoutPanel1.SetColumnSpan(historyButton, 3);
                (display as MainView).tableLayoutPanel1.SetRowSpan(historyButton, 2);
            }
            else
            {
                throw new Exception("ConstructView Display Error");
            }
        }
    }
}
