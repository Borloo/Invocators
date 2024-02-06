using Invocators.Classes;
using Invocators.Classes.Invocations;
using Invocators.Services;
using System;

namespace Invocators
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'un invocateur
            // Invocator invocator = new Invocator(500);

            // Invocation d'un guerrier
            /* Warrior warrior = new Warrior();
            Guardian guardian = new Guardian();
            invocator.Summon(warrior);
            invocator.Summon(guardian);

            while ((warrior.CurrentLife > 0) && (guardian.CurrentLife > 0) || (warrior.CurrentAttackNumber != 0) && (guardian.CurrentAttackNumber != 0)) {
                // Test d'une attaque
                invocator.ManageRoundFight();
                invocator.ManageRoundFight();

                Console.WriteLine($"Current attack number warrior : {warrior.CurrentAttackNumber}");
                Console.WriteLine($"Current attack number guardian : {guardian.CurrentAttackNumber}");

                // Affichage de l'état après l'attaque
                Console.WriteLine($"Remaining life of the warrior: {warrior.CurrentLife}");
                Console.WriteLine($"Remaining life of the guardian: {guardian.CurrentLife}");
                System.Threading.Thread.Sleep(1000);

                if ((warrior.CurrentAttackNumber == 0) || (guardian.CurrentAttackNumber == 0)){
                    Console.WriteLine("Un des deux personnages ne peut plus attaquer");
                    break;
                }
           }*/

           GameService.StartDuelGame();
            
            // Attente pour voir les résultats
            Console.WriteLine("FIN PROGRAMME");
        }
   }
}