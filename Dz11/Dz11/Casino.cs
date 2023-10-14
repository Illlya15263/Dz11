using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz11
{
    using System;

    class CasinoGame
    {
        static void Main()
        {
            Console.WriteLine("Ласкаво просимо в казино!");
            int balance = 100;

            while (balance > 0)
            {
                Console.WriteLine($"Ваш баланс: {balance}$");
                Console.Write("Ставка (введіть 0 для виходу): ");
                int bet = int.Parse(Console.ReadLine());

                if (bet == 0)
                    break;

                if (bet > balance)
                {
                    Console.WriteLine("Ви ввели ставку, яка перевищує ваш баланс. Спробуйте ще раз.");
                    continue;
                }

                int result = new Random().Next(2);

                if (result == 1)
                {
                    balance += bet;
                    Console.WriteLine("Ви виграли!");
                }
                else
                {
                    balance -= bet;
                    Console.WriteLine("Ви програли.");
                }
            }

            Console.WriteLine("Гра завершилась. Ваш баланс: " + balance + "$");
        }
    }

}
