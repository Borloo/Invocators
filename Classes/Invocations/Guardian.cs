using Invocators.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Classes.Invocations
{
    internal class Guardian : BaseInvocation
    {
        public Guardian() 
        {
            Attack = 50;
            Defense = 150;
            Initiative = 50;
            Damages = 50;
            MaximumLife = 150;
            CurrentLife = 150;
            TotalAttackNumber = 3;
            CurrentAttackNumber = 3;
        }
        public override string Name => "Guardian";
    }
}
