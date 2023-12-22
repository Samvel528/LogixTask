using LogixTask.Services.Interfaces;

namespace LogixTask.Services.Implementations
{
    public class WordAbbreviationService : IWordAbbreviationService
    {
        private readonly Dictionary<string, string> wordAbbreviations;

        public WordAbbreviationService()
        {
            wordAbbreviations = new Dictionary<string, string>
                {
                    { "Avenue", "AVE" },
                    { "apartment", "APTS" },
                    { "road", "RDS" },
                    { "street", "STS" }
                    // Add more mappings as needed
                };
        }

        public string Abbreviate(string input)
        {
            foreach (var kvp in wordAbbreviations)
            {
                input = input.Replace(kvp.Key, kvp.Value, StringComparison.OrdinalIgnoreCase);
            }
            return input;
        }
    }
}
