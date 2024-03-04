using Invocators.Classes;
using Invocators.Classes.Invocations;
using Invocators.Models;

namespace Invocators
{
    class Program
    {
        public static int RoundNumber;
        public static List<Invocator> invocators;
        public static Invocator you;
        public static Invocator bot; 
        public static List<Func<BaseInvocation>> invocationOptions;

        static void Main(string[] args)
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
            StartDuelGame();
            Console.WriteLine("FIN PROGRAMME");
        }

        public static void StartDuelGame()
        {
            while (bot.CurrentLife > 0 || you.CurrentLife > 0){
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
                    YourTurn();
                }else
                {
                    Console.WriteLine("Bot turn");
                    BotTurn();
                }
            }
            if (RoundNumber != 1)
            {
                InitiativePhase();
            }
        }

        public static void YourTurn()
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
                }
                else
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
                            if (you != null)
                            {
                                if (you.Invocations.Count == 0)
                                {
                                    Console.WriteLine("Vous n'avez pas d'invocations !");
                                }
                                else
                                {
                                    isValid = true;
                                    YourInvcationsChoices();
                                }
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
            //int input = GetInvocationChoices(you);
            int input = 0;
            bool isValid = false;
            List<Func<BaseInvocation>> invocationOptions = new List<Func<BaseInvocation>>()
                {
                    () => new Berserker(),
                    () => new Blacksmith(),
                    () => new CrazyScientist(),
                    () => new Dealer(),
                    () => new Doctor(),
                    () => new Dragon(),
                    () => new Guardian(),
                    () => new Illusionist(),
                    () => new Warrior(),
                };
            while (!isValid)
            {
                Console.WriteLine($"1 - Berserker");
                Console.WriteLine($"2 - Blacksmith");
                Console.WriteLine($"3 - Crazy Scientist");
                Console.WriteLine($"4 - Dealer");
                Console.WriteLine($"5 - Doctor");
                Console.WriteLine($"6 - Dragon");
                Console.WriteLine($"7 - Guardian");
                Console.WriteLine($"8 - Illusionist");
                Console.WriteLine($"9 - Warrior");
                string? inputChoice = Console.ReadLine();

                if (inputChoice == null)
                {
                    Console.WriteLine("Aucune entrée détectée.");
                }
                else
                {
                    if (int.TryParse(inputChoice, out input) && input > 0 && input <= invocationOptions.Count)
                    {
                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("Vous avez choisi l'invocation Berserker");
                                you.Summon(new Berserker(RoundNumber));
                                break;
                            case 2:
                                Console.WriteLine("Vous avez choisi l'invocation Blacksmith");
                                you.Summon(new Blacksmith(RoundNumber));
                                break;
                            case 3:
                                Console.WriteLine("Vous avez choisi l'invocation Crazy Scientist");
                                you.Summon(new CrazyScientist(RoundNumber));
                                break;
                            case 4:
                                Console.WriteLine("Vous avez choisi l'invocation Dealer");
                                you.Summon(new Dealer(RoundNumber));
                                break;
                            case 5:
                                Console.WriteLine("Vous avez choisi l'invocation Doctor");
                                you.Summon(new Doctor(RoundNumber));
                                break;
                            case 6:
                                Console.WriteLine("Vous avez choisi l'invocation Dragon");
                                you.Summon(new Dragon(RoundNumber));
                                break;
                            case 7:
                                Console.WriteLine("Vous avez choisi l'invocation Guardian");
                                you.Summon(new Guardian(RoundNumber));
                                break;
                            case 8:
                                Console.WriteLine("Vous avez choisi l'invocation Illusionist");
                                you.Summon(new Illusionist(RoundNumber));
                                break;
                            case 9:
                                Console.WriteLine("Vous avez choisi l'invocation Warrior");
                                you.Summon(new Warrior(RoundNumber));
                                break;
                        }
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Entrée non valide. Veuillez choisir un numéro d'invocation valide.");
                    }
                }
            }
        }

        public static int GetInvocationChoices(Invocator invocator)
        {
            int input = 0;
            bool isValid = false;
            Console.WriteLine("Your invocations");
            while (!isValid)
            {
                for (int i = 0; i < invocator.Invocations.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {invocator.Invocations[i].Name}");
                }
                string? inputChoice = Console.ReadLine();

                if (inputChoice == null)
                {
                    Console.WriteLine("Aucune entrée détectée.");
                }
                else
                {
                    if (int.TryParse(inputChoice, out input) && input > 0 && input <= invocator.Invocations.Count)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Entrée non valide. Veuillez choisir un numéro d'invocation valide.");
                    }
                }
            }
            return input;
        }

        static void YourInvcationsChoices()
        {
            bool isValid = false;
            Console.WriteLine("Your invocations");
            if (you != null)
            {
                while (!isValid)
                {
                    for (int i = 0; i < you.Invocations.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {you.Invocations[i].Name}");
                    }
                    string? inputChoice = Console.ReadLine();

                    if (inputChoice == null)
                    {
                        Console.WriteLine("Aucune entrée détectée.");
                    }
                    else
                    {
                        if (int.TryParse(inputChoice, out int input) && input > 0 && input <= you.Invocations.Count)
                        {
                            int index = input - 1;
                            BaseInvocation invocation = you.Invocations[index];
                            Console.WriteLine($"Vous avez choisi: {invocation.Name}");
                            GetAttackPossibilities(invocation);
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Entrée non valide. Veuillez choisir un numéro d'invocation valide.");
                        }
                    }
                }
            }
        }

        public static void GetAttackPossibilities(
            BaseInvocation invocation
        )
        {
            bool isValid = false;
            Console.WriteLine("Choix d'attaques");
            while (!isValid)
            {
                Console.WriteLine("1 - Zone attack");
                Console.WriteLine("2 - Alterarion");
                Console.WriteLine("3 - Target");

                string? inputChoice = Console.ReadLine();
                if (inputChoice == null)
                {
                    Console.WriteLine("Aucune entrée détectée.");
                }
                else
                {
                    if (bot != null)
                    {
                        switch (inputChoice)
                        {
                            case "1":
                                if (invocation.isTargeted)
                                {
                                    Console.WriteLine($"Vous ne pouvez pas choisir l'attaque de zone.");
                                }
                                else
                                {
                                    Console.WriteLine("Vous avez choisi l'attaque de zone.");
                                    isValid = true;
                                }
                                break;
                            case "2":
                                Console.WriteLine("Vous avez choisi l'alteration");
                                isValid = true;
                                break;
                            case "3":
                                Console.WriteLine("Vous avez choisi de cibler");
                                Console.WriteLine("1 - Bot");
                                for (int i = 1; i < bot.Invocations.Count + 1; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {bot.Invocations[i - 1].Name}");
                                }
                                string? targetChoiceInput = Console.ReadLine();
                                if (targetChoiceInput == null)
                                {
                                    Console.WriteLine("Aucune entrée détectée.");
                                }
                                else
                                {
                                    if (int.TryParse(targetChoiceInput, out int input) && input > 0 && input <= bot.Invocations.Count)
                                    {
                                        if (input == 1)
                                        {
                                            Console.WriteLine("You targeted bot");
                                            invocation.TargetInvocator = bot;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"You targeted {bot.Invocations[input - 1].Name}");
                                            invocation.TargetInvocation = bot.Invocations[input - 1];
                                        }
                                        invocation.isTargeted = true;
                                        isValid = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Entrée non valide. Veuillez choisir un numéro d'invocation valide.");
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Choix non valide. Veuillez saisir 1, 2 ou 3.");
                                break;
                        }
                    }
                }
            }
        }

        public static void BotTurn()
        {
            if (bot != null)
            {
                if (bot.Invocations.Count < 2)
                {
                    List<Func<BaseInvocation>> invocationOptions = new List<Func<BaseInvocation>>()
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
                    BaseInvocation randomInvocation = invocationOptions[new Random().Next(invocationOptions.Count)]();
                    bot.Summon(randomInvocation);
                    Console.WriteLine($"Bot has summoned: {randomInvocation.GetType().Name}");
                }
                else
                {
                    // TODO: Faire le bot attaquer
                }
            }
        }

        static void InitiativePhase()
        {
            Console.WriteLine("Phase d'initiatives");

            // TODO: Le personnage ayant fait le plus gros jet d’initiative attaque en premier.
            foreach (var (InvocatorName, InvocationName, InitiativeScore) in GetSortedlistInvocationsByRound())
            {
                Console.WriteLine($"[{InvocatorName}] {InvocationName}: {InitiativeScore}");
                // Ancienne version, qui je pense est cool à prendre

                /* Console.WriteLine("Phase d'initiatives");
                int attackRoll = invocation.CalculateAttackRoll();
                int defenseRoll = invocation.CalculateDefenseRoll();
                int attackDelta = defenseRoll - attackRoll;
                if (attackDelta < 0)
                {
                    Console.WriteLine($"Attack miss !");
                }
                else
                {
                    Console.WriteLine($"Attack success !");
                    int damage = invocation.CalculateDamage(attackDelta);
                    BaseInvocation targetInvocation = bot.GetRandomTarget();
                    if (targetInvocation != null)
                    {
                        targetInvocation.TakeDamage(attackDelta);
                        Console.WriteLine($"{invocation.Name} attack {targetInvocation.Name} and do damages {damage}");
                    }
                    else
                    {
                        bot.TakeDamage(attackDelta);
                        Console.WriteLine($"{invocation.Name} attack bot invocator and do damages {damage}");
                    }
                }
                invocation.CurrentAttackNumber--;*/
            }
        }

        public static List<(string invocatorName, string InvocationName, int InitiativeScore)> GetSortedlistInvocationsByRound()
        {
            Dictionary<Invocator, Dictionary<BaseInvocation, int>> invocatorsInitiatives = new();
            foreach (Invocator invocator in invocators)
            {
                invocatorsInitiatives.Add(invocator, invocator.GetInitiativeScores(RoundNumber));
            }
            List<(string InvocatorName, string InvocationName, int InitiativeScore)> allInitiatives = new();
            foreach (var invocatorEntry in invocatorsInitiatives)
            {
                foreach (var invocationEntry in invocatorEntry.Value)
                {
                    allInitiatives.Add((invocatorEntry.Key.Name, invocationEntry.Key.Name, invocationEntry.Value));
                }
            }
            allInitiatives.Sort((a, b) => b.InitiativeScore.CompareTo(a.InitiativeScore));
            return allInitiatives;
        }
   }
}