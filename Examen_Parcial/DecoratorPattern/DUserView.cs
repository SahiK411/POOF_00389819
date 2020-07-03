using Examen.UserControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Examen.DecoratorPattern
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
            historyButton.Click += HistoryButton_Click;

            if (Display is MainView)
            {
                (Display as MainView).tableLayoutPanel1.Controls.Add(historyButton, 1, 3);
                (Display as MainView).tableLayoutPanel1.SetColumnSpan(historyButton, 3);
                (Display as MainView).tableLayoutPanel1.SetRowSpan(historyButton, 2);
            }
            else
            {
                throw new Exception("ConstructView Display Error");
            }
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            (Display as MainView).Hide();
            HistoryUC currentUC = new HistoryUC((Display as MainView).MainUser);
            currentUC.BackButton = (Display) => {
                Control[] controls = Display.Parent.Controls.Find("MainView", true);
                Display.Dispose();
                controls[0].Show();
            };
        }
    }
}
