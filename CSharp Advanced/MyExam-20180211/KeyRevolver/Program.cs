namespace KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Program
    {
        public static void Main(string[] args)
        {
            var bulletCost = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var locks = new Queue<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var inteligence = int.Parse(Console.ReadLine());

            var totalCost = 0;
            var shotNumber = 0;
            while (bullets.Count > 0 && locks.Count > 0)
            {

                if (shotNumber == gunBarrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    shotNumber = 0;
                }
                var currentBullet = bullets.Pop();
                totalCost += bulletCost;
                var currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();

                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                shotNumber++;
            }
            if (shotNumber == gunBarrelSize && bullets.Count > 0)
            {
                Console.WriteLine("Reloading!");
                shotNumber = 0;
            }
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${inteligence - totalCost}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
