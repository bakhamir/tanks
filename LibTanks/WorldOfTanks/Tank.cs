using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTanks.WorldOfTanks
{
    public class Tank
    {
        private string _name;
        private int _ammoLevel;
        private int _armorLevel;
        private int _maneuverabilityLevel;
        private static Random _random = new Random();

        public Tank(string name)
        {
            _name = name;
            _ammoLevel = _random.Next(0, 101); 
            _armorLevel = _random.Next(0, 101);
            _maneuverabilityLevel = _random.Next(0, 101);
        }

        public string Name => _name;
        public int AmmoLevel => _ammoLevel;
        public int ArmorLevel => _armorLevel;
        public int ManeuverabilityLevel => _maneuverabilityLevel;

        public static bool operator ^(Tank tank1, Tank tank2)
        {
            int parametersExceeded = 0;

            if (tank1.AmmoLevel > tank2.AmmoLevel)
            {
                parametersExceeded++;
            }

            if (tank1.ArmorLevel > tank2.ArmorLevel)
            {
                parametersExceeded++;
            }

            if (tank1.ManeuverabilityLevel > tank2.ManeuverabilityLevel)
            {
                parametersExceeded++;
            }

            return parametersExceeded >= 2;
        }

        public static void BattleTanks()
        {
            for (int i = 0; i < 5; i++)
            {
                Tank tank1 = Tank.NewTank("T-34");
                Tank tank2 = Tank.NewTank("Pantera");

                Console.WriteLine($"Battle {i + 1}:");
                Console.WriteLine($"{tank1.Name} vs {tank2.Name}");

                if (tank1.AmmoLevel > tank2.AmmoLevel && tank1.ArmorLevel > tank2.ArmorLevel)
                {
                    Console.WriteLine($"{tank1.Name} wins!");
                }
                else if (tank2.AmmoLevel > tank1.AmmoLevel && tank2.ArmorLevel > tank1.ArmorLevel)
                {
                    Console.WriteLine($"{tank2.Name} wins!");
                }
                else
                {
                    Console.WriteLine("It's a draw!");
                }
            }
        }

        public static Tank NewTank(string name)
        {
            return new Tank(name);
        }
    }
}
