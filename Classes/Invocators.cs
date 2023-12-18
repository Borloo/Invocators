using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Classes
{
    internal class Invocators
    {
        private int maximumLife;
        private int currentLife;

        public Invocators(int maximumLife)
        {
            this.maximumLife = maximumLife;
            this.currentLife = maximumLife;
        }
    }
}
