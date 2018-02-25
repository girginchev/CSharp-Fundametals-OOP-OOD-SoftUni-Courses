using System;
using System.Text;

namespace _07.Extract_Hyperlinks
{
    public class StartUp
    {
        public static void Main()
        {
            string lines = string.Empty;
            var sb = new StringBuilder();
            while ((lines = Console.ReadLine()) != "END")
            {
                var refactor = lines.Split(" \t\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                lines = string.Join(" ", refactor).Replace(" =", "=");
                sb.Append(lines + " ");
            }

            string input = sb.ToString().Trim();
            int openIndex = input.IndexOf("<a");

            while (openIndex != -1)
            {
                int closeIndex = input.IndexOf(">", openIndex);

                var temp = input.Substring(openIndex + 2, closeIndex - (openIndex + 2)).Trim().Replace("= ", "=");
                int hrefIndex = temp.IndexOf("href=");

                if (hrefIndex == -1)
                {
                    openIndex = input.IndexOf("<a", closeIndex);
                    continue;
                }

                else if (temp[hrefIndex + 5] == '\"')
                {
                    int close = temp.IndexOf("\"", hrefIndex + 6);

                    temp = temp.Substring(hrefIndex + 6, close - (hrefIndex + 6));
                }

                else if (temp[hrefIndex + 5] == '\'')
                {
                    int close = temp.IndexOf("'", hrefIndex + 6);

                    temp = temp.Substring(hrefIndex + 6, close - (hrefIndex + 6));
                }

                else
                {
                    int close = temp.IndexOf(" ", hrefIndex + 5);

                    if (close == -1)
                    {
                        temp = temp.Substring(hrefIndex + 5);
                    }

                    else
                    {
                        temp = temp.Substring(hrefIndex + 5, close - (hrefIndex + 5));

                    }
                }
                Console.WriteLine(temp);

                openIndex = input.IndexOf("<a", closeIndex);
            }
        }
    }
}
