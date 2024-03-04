using Invocators.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Classes.Invocations
{
    internal class CrazyScientist : BaseInvocation
    {
        public CrazyScientist(int RoundSummoned = 0)
        {
            Attack = 10;
            Defense = 10;
            Initiative = 10;
            Damages = 10;
            MaximumLife = 50;
            CurrentLife = 50;
            TotalAttackNumber = 5;
            CurrentAttackNumber = 5;
            this.RoundSummoned = RoundSummoned;
        }

        public override string Name => "Crazy Scientist";
    }
}
