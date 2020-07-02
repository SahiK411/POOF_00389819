using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Parcial.DecoratorPattern
{
    public abstract class ViewDecorator : IDisplay
    {
        protected IDisplay display;

        public ViewDecorator(IDisplay ID)
        {
            this.display = ID;
        }

        public virtual void ConstructView()
        {
            return;
        }
    }
}
