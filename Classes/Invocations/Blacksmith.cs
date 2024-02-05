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
        public Blacksmith()
        {
            Attack = 10;
            Defense = 10;
            Initiative = 50;
            Damages = 50;
            MaximumLife = 200;
            CurrentLife = 200;
            TotalAttackNumber = 1;
            CurrentAttackNumber = 1;
        }

        public override string Name => "Blacksmith";
    }
}
