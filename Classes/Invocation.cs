using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Classes
{
    internal class Invocation
    {
        private int attack { get; set; }
        private int defense { get; set; }
        private int initiative { get; set; }
        private int damages { get; set; }
        private int maximumLife { get; set; }
        private int currentLife { get; set; }
        private int currentAttackNumber { get; set; }
        private int totalAttackNumber { get; set; }
        private int RoundInvocation { get; set; }

        public Invocation(
            int attack, 
            int defense, 
            int initiative, 
            int damages, 
            int maximumLife,
            int roundInvocation
            )
        {
            this.attack = attack;
            this.defense = defense;
            this.initiative = initiative;
            this.damages = damages;
            this.maximumLife = maximumLife;
            this.currentLife = maximumLife;
            this.currentAttackNumber = 2;
            this.totalAttackNumber = 2;
            this.RoundInvocation = roundInvocation;
        }

        public void Attack(Invocation targetInvocation)
        {
            if (this.currentAttackNumber > 0 && targetInvocation.currentLife > 0)
            {
                int attackRoll = this.CalculateAttackRoll();
                int defenseRoll = this.CalculateDefenseRoll();
                int attackDelta = attackRoll - defenseRoll;
                if (attackDelta > 0)
                {
                    int damage = this.CalculateDamage(attackDelta);
                    targetInvocation.EndureAttack(attackDelta);
                    Console.WriteLine($"{GetType().Name} attack {targetInvocation.GetType().Name} and do damages {damage}");
                }
                else
                {
                    Console.WriteLine($"{GetType().Name} attaque {targetInvocation.GetType().Name} mais rate !");
                }
                this.currentAttackNumber--;
            }
        }

        public void EndureAttack(int damages)
        {
            this.currentLife -= damages;
            if (this.currentLife <= 0)
            {
                Console.WriteLine($"{GetType().Name}'s dead!");
            }
        }

        private int CalculateAttackRoll()
        {
            return this.attack + new Random().Next(1, 101);
        }

        private int CalculateDefenseRoll()
        {
            return this.defense + new Random().Next(1, 101);
        }

        private int CalculateDamage(int attackDealte)
        {
            return (attackDealte * this.damages) / 100;
        }
    }
}
