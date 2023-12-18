using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Classes
{
    internal class Invocator
    {
        private int maximumLife { get; set; }
        private int currentLife { get; set; }
        private List<Invocation> invocations;

        public Invocator(int maximumLife)
        {
            this.maximumLife = maximumLife;
            this.currentLife = maximumLife;
            this.invocations = new List<Invocation>();
        }

        public void Summon(Invocation invocation)
        {
            if (this.currentLife > 0)
            {
                this.invocations.Add(invocation);
                Console.WriteLine("Succes summon");
            }
            else
            {
                Console.WriteLine("Not enough life");
            }
        }

        public void GiveOrder(Invocation invocation, string order)
        {
            if (this.invocations.Contains(invocation))
            {
                Console.WriteLine($"Order give to {invocation.GetType().Name}: {order}");
            }
            else
            {
                Console.WriteLine("Invocation doens't exist in list of invocations");
            }
        }

        public void ManageRoundFight()
        {
            foreach (var invocation in this.invocations)
            {
                Console.WriteLine($"{invocation.GetType().Name} attack!");
                invocation.Attack(this.GetRandomTarget());
            }
        }

        private Invocation GetRandomTarget()
        {
            return this.invocations[0];
        }
    }
}
