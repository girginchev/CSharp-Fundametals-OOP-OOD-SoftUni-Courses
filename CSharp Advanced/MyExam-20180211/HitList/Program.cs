namespace HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Program
    {
        static void Main(string[] args)
        {
            var targetInfoIndex = int.Parse(Console.ReadLine());

            var result = new Dictionary<string, Dictionary<string, string>>();

            string input;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                var tokens = input.Split(new char[] { '=' },StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = tokens[0];
                if (!result.ContainsKey(name))
                {
                result[name] = new Dictionary<string, string>();
                }

                var kvp = tokens[1].Split(new char[] { ':',';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int i = 0; i < kvp.Length; i+=2)
                {
                    var key = kvp[i];
                    var value = kvp[i + 1];

                    if (result[name].ContainsKey(key))
                    {
                    result[name][key] = value;
                    }
                    else
                    {
                        result[name].Add(key, value);
                    }
                }
            }

            var lastLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var kill = lastLine[1];

            var currentName = result.FirstOrDefault(x => x.Key == kill);
            if (currentName.Key != null)
            {
                Console.WriteLine($"Info on {currentName.Key}:");
                var index = currentName.Value.Sum(x => x.Key.Length + x.Value.Length);
                foreach (var kpv in currentName.Value.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"---{kpv.Key}: {kpv.Value}");
                }
                Console.WriteLine($"Info index: {index}");
                if (index >= targetInfoIndex)
                {
                    Console.WriteLine("Proceed");
                }
                else
                {
                    Console.WriteLine($"Need {targetInfoIndex - index} more info.");
                }
            }
            

        }
    }
}
