using Invocators.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Classes.Invocations
{
    internal class Doctor : BaseInvocation
    {
        public Doctor()
        {
            Attack = 10;
            Defense = 125;
            Initiative = 50;
            Damages = 50;
            MaximumLife = 150;
            CurrentLife = 150;
            TotalAttackNumber = 4;
            CurrentAttackNumber = 4;
        }

        public override string Name => "Doctor";
    }
}
