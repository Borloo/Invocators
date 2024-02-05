using Invocators.Models;
using System;
using System.Collections.Generic;

namespace Invocators.Classes
{
    internal class Invocator
    {
        private int MaximumLife { get; set; }
        private int CurrentLife { get; set; }
        public List<BaseInvocation> Invocations { get; }

        public Invocator(int maximumLife)
        {
            MaximumLife = maximumLife;
            CurrentLife = maximumLife;
            Invocations = new List<BaseInvocation>();
        }

        public void Summon(BaseInvocation invocation)
        {
            if (this.CurrentLife > 0)
            {
                this.Invocations.Add(invocation);
                Console.WriteLine("Success summon");
            }
            else
            {
                Console.WriteLine("Not enough life");
            }
        }

        public void GiveOrder(BaseInvocation invocation, string order)
        {
            if (this.Invocations.Contains(invocation))
            {
                Console.WriteLine($"Order given to {invocation.GetType().Name}: {order}");
            }
            else
            {
                Console.WriteLine("Invocation doesn't exist in the list of invocations");
            }
        }

        public void ManageRoundFight()
        {
            foreach (var invocation in this.Invocations)
            {
                Console.WriteLine($"{invocation.GetType().Name} attacks!");
                invocation.MakeAttack(GetRandomTarget());
            }
        }

        private BaseInvocation GetRandomTarget()
        {
            return this.Invocations[0];
        }
    }
}
