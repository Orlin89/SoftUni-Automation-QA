namespace _04.PokemonTrainer1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<Trainer> trainers = new List<Trainer>();

            while (command != "Tournament")
            {
                string[] data = command.Split().ToArray();
                //{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}

                Pokemon currentP = new Pokemon(data[1], data[2], int.Parse(data[3]));
                bool trainerExists = false;
                Trainer existingTrainer = new Trainer();

                foreach (Trainer trainer in trainers)
                {
                    if (data[0] == trainer.Name)
                    {
                        trainerExists = true;
                        existingTrainer = trainer;
                    }

                }

                if (trainerExists)
                {
                    existingTrainer.Pokemons.Add(currentP);
                }
                else
                {
                    Trainer currentTr = new Trainer(data[0]);
                    currentTr.Pokemons.Add(currentP);
                    trainers.Add(currentTr);
                }

                command = Console.ReadLine();
            }

            string command2 = Console.ReadLine();
            while (command2 != "End")
            {
                for (int i = 0; i < trainers.Count; i++)
                {
                    bool hasPokemon = false;

                    foreach (Pokemon pokemon in trainers[i].Pokemons)
                    {
                        if (command2 == pokemon.Element)
                            hasPokemon = true;
                    }

                    if (hasPokemon)
                        trainers[i].Badges++;
                    else
                        trainers[i].Pokemons.ForEach(p => { p.Health -= 10; });

                    trainers[i].Pokemons.RemoveAll(x => x.Health <= 0);
                }

                command2 = Console.ReadLine();
            }

            List<Trainer> sortedList = trainers.OrderByDescending(x => x.Badges).ToList();
            foreach (Trainer t in sortedList)
            {
                Console.WriteLine($"{t.Name} {t.Badges} {t.Pokemons.Count}");
            }

        }

        public class Trainer
        {
            public Trainer() { }          //празен конструктор
            public Trainer(string name)   //конструктор който приема име на треньора
            {
                this.Name = name;
                this.Badges = 0;
                this.Pokemons = new List<Pokemon>();
            }

            public string Name { get; set; }
            public int Badges { get; set; }
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
}
