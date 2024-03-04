using Invocators.Models;
using System;
using System.Collections.Generic;

namespace Invocators.Classes
{
    internal class Invocator
    {
        public string Name {  get; set; }
        public int MaximumLife { get; set; }
        public int CurrentLife { get; set; }
        public List<BaseInvocation> Invocations { get; }

        public Invocator(string name, int maximumLife)
        {
            this.Name = name;
            this.MaximumLife = maximumLife;
            this.CurrentLife = maximumLife;
            this.Invocations = new List<BaseInvocation>();
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

        public BaseInvocation GetRandomTarget()
        {
            if (this.Invocations.Count + 1 > 1)
            {
                int Random = new Random().Next(this.Invocations.Count);
                if (Random != 0)
                {
                    return this.Invocations[Random];
                }
            }
            return null;
        }

        public void TakeDamage(int damages)
        {
            this.CurrentLife -= damages;
            if (this.CurrentLife <= 0)
            {
                Console.WriteLine($"{this.Name}'s dead!");
            }
        }

        public Dictionary<BaseInvocation, int> GetInitiativeScores(int RoundNumber)
        {
            Dictionary<BaseInvocation, int> initiativeScores = new();
            foreach (BaseInvocation invocation in Invocations)
            {
                if (invocation.IsReady(RoundNumber))
                {
                    invocation.InitiativeThrow = invocation.Initiative + new Random().Next(0, 100);
                    initiativeScores.Add(invocation, invocation.InitiativeThrow);
                }
            }
            return initiativeScores;
        }
    }
}
