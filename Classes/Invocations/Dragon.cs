using Invocators.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Classes.Invocations
{
    internal class Dragon : BaseInvocation
    {
        public Dragon()
        {
            Attack = 150;
            Defense = 10;
            Initiative = -50;
            Damages = 150;
            MaximumLife = 1000;
            CurrentLife = 1000;
            TotalAttackNumber = 1;
            CurrentAttackNumber = 1;
        }

        public override string Name => "Dragon";
    }
}
