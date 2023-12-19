using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Models
{
    internal abstract class BaseInvocation : IInvocation
    {
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Initiative { get; set; }
        public int Damages { get; set; }
        public int MaximumLife { get; set; }
        public int CurrentLife { get; set; }
        public int TotalAttackNumber { get; set; }
        public int CurrentAttackNumber { get; set; }

        public abstract string Name { get; }

        public void MakeAttack(BaseInvocation targetInvocation)
        {
            if (this.CurrentAttackNumber > 0 && targetInvocation.CurrentLife > 0)
            {
                int attackRoll = this.CalculateAttackRoll();
                int defenseRoll = this.CalculateDefenseRoll();
                int attackDelta = attackRoll - defenseRoll;
                if (attackDelta > 0)
                {
                    int damage = this.CalculateDamage(attackDelta);
                    targetInvocation.TakeDamage(attackDelta);
                    Console.WriteLine($"{GetType().Name} attack {targetInvocation.GetType().Name} and do damages {damage}");
                }
                else
                {
                    Console.WriteLine($"{GetType().Name} attack {targetInvocation.GetType().Name} but miss!");
                }
                this.CurrentAttackNumber--;
            }
        }

        public void TakeDamage(int damages)
        {
            this.CurrentLife -= damages;
            if (this.CurrentLife <= 0)
            {
                Console.WriteLine($"{GetType().Name}'s dead!");
            }
        }

        private int CalculateAttackRoll()
        {
            return this.Attack + new Random().Next(1, 101);
        }

        private int CalculateDefenseRoll()
        {
            return this.Defense + new Random().Next(1, 101);
        }

        private int CalculateDamage(int attackDelta)
        {
            return (attackDelta * this.Damages) / 100;
        }
    }
}
