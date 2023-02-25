namespace DZ6
{
    internal class Program
    {
        static void Main()
        {
            Planet venus = new("Венера", 2, 38052, null);
            Planet earth = new("Земля", 3, 40076, venus);
            Planet mars = new("Марс", 4, 21344, earth);

            PlanetsCatalog planets = new PlanetsCatalog(venus, earth, mars);

            List<string> names = new List<string>() { "Земля", "Лимония", "Марс"};

            foreach (var name in names)
            {
                var answer = planets.GetPlanet(name);

                if (answer.answer == null)
                {
                    Console.WriteLine($"[Номер : {answer.number}, Длина эватора : {answer.equatorLenth}]");
                }

                Console.WriteLine(answer.answer);
            }

        }

        class Planet
        {
            public string Name { get; }
            public int Number { get; }
            public int EquatorLenth { get; }
            public Planet PreviousPlanet { get; }
            public Planet(string name, int number, int equatorLenth, Planet previousPlanet)
            {
                Name = name;
                Number = number;
                EquatorLenth = equatorLenth;
                PreviousPlanet = previousPlanet;
            }
        }

        class PlanetsCatalog
        {
            public List<Planet> Planets { get; }
            private int call = 1;

            public PlanetsCatalog(Planet planet1, Planet planet2, Planet planet3)
            {
                Planets = new List<Planet>
                {
                    planet1,
                    planet2,
                    planet3
                };
            }

            public (int number, int equatorLenth, string answer) GetPlanet(string name)
            {
                if (call == 3)
                {
                    call = 1;
                    return (0, 0, "Вы спрашиваете слишком часто.");
                }

                foreach (var planet in Planets)
                {
                    if (planet.Name == name)
                    {
                        call++;
                        return (planet.Number, planet.EquatorLenth, null);
                    }
                }

                call++;
                return (0, 0, "Не удалось найти планету.");
            }
        }

    }
}