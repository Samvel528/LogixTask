using LogixTask.Services.Interfaces;
using System.Text.RegularExpressions;

namespace LogixTask.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IWordAbbreviationService wordAbbreviationService;
        private static readonly string _pattern = @"(\d+)\s*([a-zA-Z\s]+)\s*(\d+)";

        public AddressService(IWordAbbreviationService wordAbbreviationService)
        {
            this.wordAbbreviationService = wordAbbreviationService;
        }

        public string ProcessAddress(string input)
        {
            // Use a regular expression to parse the input and extract components
            // Create an Address object and set its properties
            // Abbreviate the street name using the word abbreviation service

            Match match = Regex.Match(input, _pattern);
            if (match.Success)
            {
                string address = match.Groups[1].Value.Trim().ToUpper() + ' '
                    + wordAbbreviationService.Abbreviate(match.Groups[2].Value).Trim().ToUpper() + ' '
                    + match.Groups[3].Value.Trim().ToUpper();

                return address;
            }

            return input;
        }
    }
}
