using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invocators.Classes;
using Invocators.Classes.Invocations;
using Invocators.Models;

namespace Invocators.Services
{
    internal class GameService
    {
        public static int RoundNumber;
        public static List<Invocator> invocators;
        public static Invocator you;
        public static Invocator bot;
        public static List<Func<BaseInvocation>> invocationOptions;

        static GameService()
        {
            you = new("You", 500);
            bot = new("Bot", 500);
            invocators = new List<Invocator>
            {
                you,
                bot
            };
            RoundNumber = 0;
            invocationOptions = new List<Func<BaseInvocation>>()
                        {
                            () => new Berserker(),
                            () => new Blacksmith(),
                            () => new CrazyScientist(),
                            () => new Dealer(),
                            () => new Doctor(),
                            () => new Guardian(),
                            () => new Illusionist(),
                            () => new Warrior(),
                        };
        }

        public static void StartDuelGame()
        {
            while (bot.CurrentLife > 0 && you.CurrentLife > 0){
                RoundNumber++;
                Console.WriteLine($"Start round n°{RoundNumber}");
                foreach (Invocator invocator in invocators)
                {
                    Console.WriteLine($"{invocator.Name}: {invocator.CurrentLife}/{invocator.MaximumLife} hp");
                }
                ManageRound();
            }
        }

        static void ManageRound()
        {
            foreach (Invocator invocator in invocators)
            {
                if (invocator == you)
                {
                    Console.WriteLine("Your turn");
                    InvocatorChoices();
                }else
                {
                    Console.WriteLine("Bot turn");
                    if (bot.Invocations.Count < 2){
                        // Sélectionnez au hasard une invocation de la liste
                        Random random = new();
                        int index = random.Next(invocationOptions.Count); // Obtient un index au hasard
                        BaseInvocation randomInvocation = invocationOptions[index](); // Crée une instance de l'invocation

                        bot.Summon(randomInvocation);
                        Console.WriteLine($"Bot has summoned: {randomInvocation.GetType().Name}");
                    }
                }
            }
        }

        static void InvocatorChoices()
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("1 - Invocation");
                Console.WriteLine("2 - Donner un ordre");
                string? inputChoice = Console.ReadLine();

                if (inputChoice == null)
                {
                    Console.WriteLine("Aucune entrée détectée. Fin du programme.");
                } else 
                {
                    switch (inputChoice)
                    {
                        case "1":
                            Console.WriteLine("Vous avez choisi l'invocation.");
                            isValid = true;
                            InvocationsChoices();
                            break;
                        case "2":
                            Console.WriteLine("Vous avez choisi de donner un ordre.");
                            if (you.Invocations.Count == 0) {
                                Console.WriteLine("Vous n'avez pas d'invocations !");
                            } else{
                                isValid = true;
                                Console.WriteLine("TODO: Choix des attaques");
                            }
                            break;
                        default:
                            Console.WriteLine("Choix non valide. Veuillez saisir 1 ou 2.");
                            break; 
                    }
                }
            }
        }

        static void InvocationsChoices()
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("1 - Berseker");
                Console.WriteLine("2 - Blacksmith");
                Console.WriteLine("3 - Crazy Scientist");
                Console.WriteLine("4 - Dealer");
                Console.WriteLine("5 - Doctor");
                Console.WriteLine("6 - Dragon");
                Console.WriteLine("7 - Guardian");
                Console.WriteLine("8 - Illusionist");
                Console.WriteLine("9 - Warrior");
                string? inputChoice = Console.ReadLine();

                if (inputChoice == null)
                {
                    Console.WriteLine("Aucune entrée détectée. Fin du programme.");
                }
                else
                {
                    switch (inputChoice)
                    {
                        case "1":
                            Console.WriteLine("Vous avez choisi l'invocation Berserker");
                            isValid = true;
                            you.Summon(new Berserker());
                            break;
                        case "2":
                            Console.WriteLine("Vous avez choisi l'invocation Blacksmith");
                            isValid = true;
                            you.Summon(new Blacksmith());
                            break;
                        case "3":
                            Console.WriteLine("Vous avez choisi l'invocation Crazy Scientist");
                            isValid = true;
                            you.Summon(new CrazyScientist());
                            break;
                        case "4":
                            Console.WriteLine("Vous avez choisi l'invocation Dealer");
                            isValid = true;
                            you.Summon(new Dealer());
                            break;
                        case "5":
                            Console.WriteLine("Vous avez choisi l'invocation Doctor");
                            isValid = true;
                            you.Summon(new Doctor());
                            break;
                        case "6":
                            Console.WriteLine("Vous avez choisi l'invocation Dragon");
                            isValid = true;
                            you.Summon(new Dragon());
                            break;
                        case "7":
                            Console.WriteLine("Vous avez choisi l'invocation Guardian");
                            isValid = true;
                            you.Summon(new Guardian());
                            break;
                        case "8":
                            Console.WriteLine("Vous avez choisi l'invocation Illusionist");
                            isValid = true;
                            you.Summon(new Illusionist());
                            break;
                        case "9":
                            Console.WriteLine("Vous avez choisi l'invocation Warrior");
                            isValid = true;
                            you.Summon(new Warrior());
                            break;
                        default:
                            Console.WriteLine("Choix non valide. Veuillez saisir une option valide.");
                            break; // reste dans la boucle pour un autre choix
                    }
                }
            }
        }
    }
}
