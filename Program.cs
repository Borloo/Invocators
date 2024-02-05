using Invocators.Classes;
using Invocators.Classes.Invocations;
using System;

namespace Invocators
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'un invocateur
            Invocator invocator = new Invocator(500);

            // Invocation d'un guerrier
            Warrior warrior = new Warrior();
            Guardian guardian = new Guardian();
            invocator.Summon(warrior);
            invocator.Summon(guardian);

            // Test d'une attaque
            invocator.ManageRoundFight();
            invocator.ManageRoundFight();

            // Affichage de l'état après l'attaque
            Console.WriteLine($"Remaining life of the warrior: {warrior.CurrentLife}");

            // Attente pour voir les résultats
            Console.ReadLine();
        }
    }
}