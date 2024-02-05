using Invocators.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Classes.Invocations
{
    internal class Berserker : BaseInvocation
    {
        public Berserker()
        {
            Attack = 100;
            Defense = 100;
            Initiative = 80;
            Damages = 20;
            MaximumLife = 300;
            CurrentLife = 300;
            TotalAttackNumber = 1;
            CurrentAttackNumber = 1;
        }

        public override string Name => "Berserker";
    }
}
