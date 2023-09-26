using System.Text;

namespace Crip_117.Utilities
{
    public class AccentuationHandler
    {
        public string HandleAccentuation(char accentChar)
        {
            switch (accentChar)
            {
                case '´':
                    return GetAccentuatedCharacter('´', 'A', '+');
                case '`':
                    return GetAccentuatedCharacter('`', 'E', '-');
                case '~':
                    return GetAccentuatedCharacter('~', 'I', '*');
                case '^':
                    return GetAccentuatedCharacter('^', 'O', '/');
                case '¨':
                    return GetAccentuatedCharacter('¨', 'U', '=');
                default:
                    return accentChar.ToString();
            }
        }

        private static string GetAccentuatedCharacter(char accentChar, char baseChar, char operationChar)
        {
            string encryptedValue = new AlphabetEnumerator().GetAlphabetValue(baseChar);

            if (encryptedValue.Length > 0)
            {
                char firstChar = encryptedValue[0];
                return firstChar + operationChar.ToString();
            }

            return accentChar.ToString();
        }

        public string HandleAccentuation(string input)
        {
            var result = new StringBuilder();

            foreach (char c in input)
            {
                result.Append(HandleAccentuation(c));
            }

            return result.ToString();
        }
    }
}
