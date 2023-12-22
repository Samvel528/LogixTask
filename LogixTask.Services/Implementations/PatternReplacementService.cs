using LogixTask.Services.Interfaces;
using System.Text.RegularExpressions;

namespace LogixTask.Services.Implementations
{
    public class PatternReplacementService : IPatternReplacementService
    {
        public string ReplacePattern(string input)
        {
            // Define regular expressions for matching patterns
            Regex[] patterns = {
                new Regex(@"No (\d+)"),
                new Regex(@"#(\d+)"),
                new Regex(@"No\. (\d+)"),
                new Regex(@"Number (\d+)")
            };

            // Replace matched patterns with the desired format
            foreach (var pattern in patterns)
            {
                input = pattern.Replace(input, "$1");
            }

            return input;
        }
    }
}
