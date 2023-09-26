using System.Linq;

namespace Crip_117.Utilities
{
    public class AlphabetEnumerator
    {
        private static readonly Dictionary<char, string> Alphabet = new Dictionary<char, string>
        {
            // Grupo A: A - F
            { 'A', "26" }, { 'B', "25" }, { 'C', "24" }, { 'D', "23" }, { 'E', "22" }, { 'F', "21" },
        
            // Grupo B: G
            { 'G', "20" },
        
            // Grupo C: H - M
            { 'H', "19" }, { 'I', "18" }, { 'J', "17" }, { 'K', "16" }, { 'L', "15" }, { 'M', "14" },

            // Grupo N: N - S
            { 'N', "01" }, { 'O', "02" }, { 'P', "03" }, { 'Q', "04" }, { 'R', "05" }, { 'S', "06" },

            // Grupo T: T
            { 'T', "07" },
        
            // Grupo U: U - Z
            { 'U', "08" }, { 'V', "09" }, { 'W', "10" }, { 'X', "11" }, { 'Y', "12" }, { 'Z', "13" }
        };

         private static readonly Dictionary<char, string> UpperAlphabet = ReplaceGroupValues(
            SubstituteFirstDigitUpper(
                TransformLetterValues(
                    InvertLetterValues(
                        Alphabet
                        )
                    )
                )
            );

        private static readonly Dictionary<char, string> LowerAlphabet = ReplaceToLowerLetter(
            ReplaceGroupValues(
                SubstituteFirstDigitLower(
                    TransformLetterValues(
                        InvertLetterValues(
                            Alphabet
                            )
                        )
                    )
                )
            );

        private static Dictionary<char, string> InvertLetterValues(Dictionary<char, string> originalValues)
        {
            var invertedValues = new Dictionary<char, string>();
            foreach (var pair in originalValues)
            {
                invertedValues[pair.Key] = InvertNumber(pair.Value);
            }
            return invertedValues;
        }

        private static string InvertNumber(string number)
        {
            // Inverte os dígitos de uma string de número (por exemplo, "26" -> "62")
            char[] charArray = number.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static Dictionary<char, string> TransformLetterValues(Dictionary<char, string> originalValues)
        {
            var transformedValues = new Dictionary<char, string>();
            foreach (var pair in originalValues)
            {
                transformedValues[pair.Key] = TransformValue(pair.Value);
            }
            return transformedValues;
        }

        private static string TransformValue(string value)
        {
            // Pega o primeiro algarismo do valor, multiplica por 2 e subtrai do valor
            if (value.Length > 0 && Char.IsDigit(value[0]))
            {
                int firstDigit = int.Parse(value[0].ToString());
                int transformedValue = int.Parse(value) - (firstDigit * 2);
                return transformedValue < 10 ? "0"+transformedValue.ToString() : transformedValue.ToString();
            }
            return value; // Mantém o valor inalterado se não for um número
        }

        private static Dictionary<char, string> SubstituteFirstDigitUpper(Dictionary<char, string> originalValues)
        {
            var substitutedValues = new Dictionary<char, string>();
            foreach (var pair in originalValues)
            {
                substitutedValues[pair.Key] = SubstituteDigitUpper(pair.Value);
            }
            return substitutedValues;
        }

        private static string SubstituteDigitUpper(string value)
        {
            // Substitui o primeiro algarismo do valor por uma letra
            if (value.Length > 0 && Char.IsDigit(value[0]))
            {
                int firstDigit = int.Parse(value[0].ToString());

                char substitutedLetter;
                if (firstDigit % 2 == 0)
                {
                    // Se o primeiro algarismo for par, substitua por uma letra minúscula
                    substitutedLetter = (char)('a' + firstDigit);
                }
                else
                {
                    // Se o primeiro algarismo for ímpar, substitua por uma letra maiúscula
                    substitutedLetter = (char)('A' + firstDigit);
                }

                // Substitua o primeiro algarismo pelo caractere correspondente
                return substitutedLetter + value.Substring(1);
            }
            return value; // Mantém o valor inalterado se não começar com um dígito
        }

        private static Dictionary<char, string> SubstituteFirstDigitLower(Dictionary<char, string> originalValues)
        {
            var substitutedValues = new Dictionary<char, string>();
            foreach (var pair in originalValues)
            {
                substitutedValues[pair.Key] = SubstituteDigitLower(pair.Value);
            }
            return substitutedValues;
        }

        private static string SubstituteDigitLower(string value)
        {
            // Substitui o primeiro algarismo do valor por uma letra minúscula ou maiúscula
            if (value.Length > 0 && Char.IsDigit(value[0]))
            {
                int firstDigit = int.Parse(value[0].ToString());

                char substitutedLetter;
                if (firstDigit % 2 == 0)
                {
                    // Se o primeiro algarismo for par, substitua por uma letra maiúscula
                    substitutedLetter = (char)('A' + firstDigit);
                }
                else
                {
                    // Se o primeiro algarismo for ímpar, substitua por uma letra minúscula
                    substitutedLetter = (char)('a' + firstDigit);
                }

                // Substitua o primeiro algarismo pelo caractere correspondente
                return substitutedLetter + value.Substring(1);
            }
            return value; // Mantém o valor inalterado se não começar com um dígito
        }

        private static Dictionary<char, string> ReplaceGroupValues(Dictionary<char, string> originalValues)
        {
            var replacedValues = new Dictionary<char, string>();
            foreach (var pair in originalValues)
            {
                replacedValues[pair.Key] = ReplaceValue(originalValues, pair.Key);
            }
            return replacedValues;
        }

        private static string ReplaceValue(Dictionary<char, string> originalValues, char letter)
        {
            switch (letter)
            {
                // Grupo A (A - F) -> Grupo F (U - Z)
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                    return originalValues[(char)(letter + 20)];

                // Grupo C (H - M) -> Grupo D (N - S)
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                    return originalValues[(char)(letter + 4)];

                // Grupo F (U - Z) -> Grupo A (A - F)
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                    return originalValues[(char)(letter - 20)];

                // Grupo D (N - S) -> Grupo C (H - M)
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                    return originalValues[(char)(letter - 4)];

                default:
                    return originalValues[letter]; // Mantém o valor inalterado para outros casos
            };
        }

        private static Dictionary<char, string> ReplaceToLowerLetter(Dictionary<char, string> originalValues)
        {
            var ReplacedLetters = new Dictionary<char, string>();

            foreach (var pair in originalValues)
            {
                var key = pair.Key.ToString().ToLower().ToCharArray()[0];

                ReplacedLetters[key] = pair.Value;
            }

            return ReplacedLetters;
        }

        public class AlphabetNotFoundException : Exception
        {
            public AlphabetNotFoundException() { }

            public AlphabetNotFoundException(char letter)
                : base($"A letra '{letter}' não foi encontrada no dicionário.")
            { }
        }

        public class InvalidAlphabetCaseException : Exception
        {
            public InvalidAlphabetCaseException() { }

            public InvalidAlphabetCaseException(char letter)
                : base($"A letra '{letter}' não é maiúscula nem minúscula.")
            { }
        }

        private static string GetUpperAlphabetValue(char letter)
        {
            if (UpperAlphabet.ContainsKey(letter))
            {
                return UpperAlphabet[letter];
            }
            throw new AlphabetNotFoundException(letter);
        }

        private static string GetLowerAlphabetValue(char letter)
        {
            if (LowerAlphabet.ContainsKey(letter))
            {
                return LowerAlphabet[letter];
            }
            throw new AlphabetNotFoundException(letter);
        }

        public string GetAlphabetValue(char letter)
        {
            if (Char.IsUpper(letter))
            {
                return GetUpperAlphabetValue(letter);
            }
            else if (Char.IsLower(letter))
            {
                return GetLowerAlphabetValue(letter);
            }
            throw new InvalidAlphabetCaseException(letter);
        }

        public string GetAlphabetValue(string text)
        {
            var NewText = string.Empty;

            foreach (var c in text)
            {
                NewText += GetAlphabetValue(c);
            }

            return NewText;
        }
    }
}
