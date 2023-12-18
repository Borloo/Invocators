using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Classes
{
    internal class Invocation
    {
        private int attack;
        private int defense;
        private int initiative;
        private int damages;
        private int maximumLife;
        private int currentLife;
        private int currentAttackNumber;
        private int totalAttackNumber;

        public Invocation(
            int attack, 
            int defense, 
            int initiative, 
            int damages, 
            int maximumLife, 
            int currentLife, 
            int currentAttackNumber, 
            int totalAttackNumber
            )
        {
            this.attack = attack;
            this.defense = defense;
            this.initiative = initiative;
            this.damages = damages;
            this.maximumLife = maximumLife;
            this.currentLife = currentLife;
            this.currentAttackNumber = currentAttackNumber;
            this.totalAttackNumber = totalAttackNumber;
        }

        public int throwAttack()
        {
            Random random = new Random();
            return this.attack + random.Next(100);
        }
    }
}
