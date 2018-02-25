using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _11.Semantic_HTML
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string line = string.Empty;

            var stack = new Stack<string>();
            var sb = new StringBuilder();
            var tags = new string[]
            {
                "main", "header", "nav", "article", "section", "aside" , "footer"
            };

            while ((line = Console.ReadLine()) != "END")
            {
                string pattern = @"<(?<forReplace>div).+?>";
                var openTag = Regex.Match(line, pattern);

                string secondPattern = @"<\/div>\s*<!--\s*[a-z]+\s*-->";
                var closeTag = Regex.Match(line, secondPattern);

                if (openTag.Success)
                {
                    string innerPattern = @"(?<match>\s*(?:id|class)\s*=\s*""(?<right>.+?)"")";

                    var innerMatch = Regex.Match(openTag.Value, innerPattern);
                    string word = innerMatch.Groups["right"].Value;

                    if (tags.Contains(word))
                    {
                        stack.Push(word);

                        line = Regex.Replace(line, openTag.Groups["forReplace"].Value, word);
                        line = Regex.Replace(line, innerMatch.Groups["match"].Value, "").Replace("< ", "<")
                            .Replace(" >", ">");

                        sb.AppendLine(line);
                        continue;
                    }
                }

                if (closeTag.Success && stack.Count > 0)
                {
                    line = Regex.Replace(line, closeTag.Value, $"</{stack.Pop()}>");
                    sb.AppendLine(line);
                    continue;
                }

                sb.AppendLine(line);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
