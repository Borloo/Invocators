using Invocators.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Classes.Invocations
{
    internal class Dealer : BaseInvocation
    {
        public Dealer(int RoundSummoned = 0)
        {
            Attack = 100;
            Defense = 50;
            Initiative = 120;
            Damages = 50;
            MaximumLife = 300;
            CurrentLife = 300;
            TotalAttackNumber = 2;
            CurrentAttackNumber = 2;
            this.RoundSummoned = RoundSummoned;
        }

        public override string Name => "Dealer";
    }
}
