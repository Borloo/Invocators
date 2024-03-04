using Invocators.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Classes.Invocations
{
    internal class Blacksmith : BaseInvocation
    {
        public Blacksmith(int RoundSummoned = 0)
        {
            Attack = 10;
            Defense = 10;
            Initiative = 50;
            Damages = 50;
            MaximumLife = 200;
            CurrentLife = 200;
            TotalAttackNumber = 1;
            CurrentAttackNumber = 1;
            this.RoundSummoned = RoundSummoned;
        }

        public override string Name => "Blacksmith";
    }
}
