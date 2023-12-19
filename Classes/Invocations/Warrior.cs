using Invocators.Models;

namespace Invocators.Classes.Invocations
{
    internal class Warrior : BaseInvocation
    {
        public Warrior()
        {
            Attack = 100;
            Defense = 100;
            Initiative = 50;
            Damages = 100;
            MaximumLife = 200;
            CurrentLife = 200;
            TotalAttackNumber = 1;
            CurrentAttackNumber = 1;
        }

        public override string Name => "Warrior";
    }

}
