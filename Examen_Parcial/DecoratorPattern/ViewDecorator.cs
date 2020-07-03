using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen.DecoratorPattern
{
    public abstract class ViewDecorator : IDisplay
    {
        protected IDisplay display;
        public delegate void OnDisplayRemoved(object sender, ControlEventArgs e);
        public OnDisplayRemoved ODRemoved;

        public ViewDecorator(IDisplay ID)
        {
            Display = ID;
        }

        public IDisplay Display { get => display; set => display = value; }

        public virtual void ConstructView()
        {
            return;
        }
    }
}
