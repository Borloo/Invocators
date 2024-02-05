using Invocators.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Classes.Invocations
{
    internal class Illusionist : BaseInvocation
    {
        public Illusionist()
        {
            Attack = 10;
            Defense = 75;
            Initiative = 120;
            Damages = 10;
            MaximumLife = 75;
            CurrentLife = 75;
            TotalAttackNumber = 1;
            CurrentAttackNumber = 1;
        }

        public override string Name => "Illusionist";
    }
}
