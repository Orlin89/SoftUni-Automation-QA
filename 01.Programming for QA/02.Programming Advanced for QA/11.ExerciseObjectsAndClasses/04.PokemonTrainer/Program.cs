using System.Linq;

namespace _04.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {          
            List<Trainers>trainers = new List<Trainers>();
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string trainerName = input[0];
                if (trainerName == "Tournament")
                {
                    break;
                }
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int healt = int.Parse(input[3]);
                

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, healt);              
                Trainers trainer = new Trainers(trainerName);
                Trainers currTrainer = new Trainers();

                foreach (Trainers name in trainers)
                {
                    if (name.Name == trainerName)
                    {
                        currTrainer = name;
                        currTrainer.Pokemons.Add(pokemon);
                    }
                    else
                    {
                        trainers.Add(trainer);
                        trainer.Pokemons.Add(pokemon);
                    }
                }
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")                  
                {
                    break ;
                }
                else if (command == "Fire")
                {
                    for (int i = 0; i < trainers.Count; i++)
                    {
                        foreach (Pokemon pokemon in trainers[i].Pokemons)
                        {
                           if (pokemon.Element == "Fire" )
                           {
                                trainers[i].NumberOfBadges++;   
                           }
                           else
                           {
                                var pokemonsToRemove = new List<Pokemon>();      ryryryryryrtye
                                pokemon.Health -= 10;
                                if (pokemon.Health <= 0)
                                {
                                   trainers[i].Pokemons.Remove(pokemon);       ertgetetertrwetewrt
                                }
                           }
                        }
                    }
                }

                else if (command == "Water")
                {
                    for (int i = 0; i < trainers.Count; i++)
                    {
                        foreach (Pokemon pokemon in trainers[i].Pokemons)
                        {
                            if (pokemon.Element == "Water")
                            {
                                trainers[i].NumberOfBadges++;
                            }
                            else
                            {
                                pokemon.Health -= 10;
                                if (pokemon.Health <= 0)
                                {
                                    trainers[i].Pokemons.Remove(pokemon);
                                }
                            }
                        }
                    }
                }

                else if (command == "Electricity")
                {
                    for (int i = 0; i < trainers.Count; i++)
                    {
                        foreach (Pokemon pokemon in trainers[i].Pokemons)
                        {
                            if (pokemon.Element == "Electricity")
                            {
                                trainers[i].NumberOfBadges++;
                            }
                            else
                            {
                                pokemon.Health -= 10;
                                if (pokemon.Health <= 0)
                                {
                                    trainers[i].Pokemons.Remove(pokemon);
                                }
                            }
                        }
                    }
                }
                foreach (Trainers item in trainers)
                {
                    trainers = trainers.OrderByDescending(t => t.NumberOfBadges).ToList();
                }
                foreach (var trainer in trainers)
                {
                    Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
                }
            }
        }
    }

    public class Trainers
    {
        public Trainers()
        { 
        }
        public Trainers(string trainerName)
        {
           Name = trainerName;
           NumberOfBadges = 0;
            Pokemons = new List<Pokemon>();
        }

         public string Name { get; set; }
         public int NumberOfBadges { get; set; } = 0;
        public List<Pokemon> Pokemons { get; set; }

    }

    public class Pokemon
    {
        public Pokemon(string name, string element, int health)
        {
            Name = name;
            Element = element;
            Health = health;
        }

        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
