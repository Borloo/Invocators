namespace Invocators.Models.Invocations
{
    internal class Warrior : BaseInvocation
    {
        public Warrior() {
            this.Attack = 100;
            this.Defense = 100;
            this.Initiative = 50;
            this.Damages = 100;
            this.MaximumLife = 200;
            this.CurrentLife = 200;
            this.TotalAttackNumber = 1;
            this.CurrentAttackNumber = 1;
        }

        public override string Name => "Warrior";
    }

}
