using Newtonsoft.Json;

namespace TestCreationExam.Common
{
    public class Utils
    {
        // Any methods that aren't WebDriver specific and are used by more than one page object and/or test go here

        /// <summary>
        /// The path to the GlobalTestData.json file.
        /// </summary>
        public static string GlobalTestDataPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory) + @"\GlobalTestData.json";

        /// <summary>
        /// Holds the configuration data from the JSON file.
        /// </summary>
        public static Dictionary<string, string> ConfigData { get; } = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(GlobalTestDataPath)) ?? throw new InvalidOperationException("GlobalTestData.json contents must be valid.");

        /// <summary>
        /// Holds a static Random for use in the project.
        /// </summary>
        public static Random Rnd = new Random();

        /// <summary>
        /// Holds a static Dictionary to make referencing the string representation in number or name format easier.
        /// </summary>
        private static Dictionary<string, string> Months = new Dictionary<string, string>() {
                {"01", "January" },
                {"02", "February" },
                {"03", "March" },
                {"04", "April" },
                {"05", "May" },
                {"06", "June" },
                {"07", "July" },
                {"08", "August" },
                {"09", "September"},
                {"10", "October" },
                {"11", "November" },
                {"12", "December" }
            };

        /// <summary>
        /// A static string of all lower case and upper case letters in the alphabet.
        /// </summary>
        private const string AllCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// A static string of all numbers.
        /// </summary>
        private const string AllDigits = "0123456789";

        /// <summary>
        /// Static lambda expression that returns a single random character from the AllCharacters string.
        /// </summary>
        private static char GrabRandomCharacter => AllCharacters[Rnd.Next(AllCharacters.Length)];

        /// <summary>
        /// Static lambda expression that returns a single random numeric character from the AllDigits string.
        /// </summary>
        private static char GrabRandomDigitCharacter => AllDigits[Rnd.Next(AllDigits.Length)];

        /// <summary>
        /// Static lambda expression that returns a single random numeric character starting from 0 to one below the number inputted into section.
        /// <param name="section">Determines the section of digits that are returnable.</param>
        /// <returns>A single random numeric character from 0 to section inputted minus one.</returns>
        private static char GrabRandomDigitStringFromSection(int section) => AllDigits[Rnd.Next(Math.Clamp(section, 1, AllDigits.Length))];

        /// <summary>
        /// Static lambda expression that takes the month inputted as string of digits and returns the word form of the month as a string.
        /// </summary>
        /// <param name="month">Two character string that represents the months as digits.</param>
        /// <returns>A string of the word form of the month.</returns>
        private static string ConvertMonthDigitsToWord(string month) => Months[month];

        /// <summary>
        /// Static lambda expression Takes a string and replaces the last character with a random number, does not prevent result from being a duplicate of the value entered.
        /// </summary>
        /// <param name="columnData">A string that is expected to have a digit at the end.</param>
        /// <returns>The same string but the character has been changed to a random character digit.</returns>
        public static string ConvertToRandomRowData(string columnData) => $"{columnData.Substring(0, columnData.Length - 1)}{GrabRandomDigitCharacter}";

        /// <summary>
        /// Creates a random character string of a given length that is limited to as low as a single character and up to 100 characters.
        /// </summary>
        /// <param name="numberOfCharacters">Number of random characters to generate.</param>
        /// <returns>A randomized string of all lower case and upper case characters.</returns>
        public static string GetRandomCharacterString(int numberOfCharacters)
        {
            numberOfCharacters = Math.Clamp(numberOfCharacters, 1, 100);
            string result = string.Empty;
            while (numberOfCharacters > 0)
            {
                numberOfCharacters--;
                result = string.Concat(result, GrabRandomCharacter);
            }
            return result;
        }

        /// <summary>
        /// Creates a random digit string of a given length that is limited to as low as a single character and up to 100 characters.
        /// </summary>
        /// <param name="numberOfDigits"></param>
        /// <returns></returns>
        public static string GetRandomDigitString(int numberOfDigits)
        {
            numberOfDigits = Math.Clamp(numberOfDigits, 1, 100);
            string result = string.Empty;
            while (numberOfDigits > 0)
            {
                numberOfDigits--;
                result = string.Concat(result, GrabRandomDigitCharacter);
            }
            return result;
        }

        /// <summary>
        /// Generates a valid random month as a two digit string.
        /// </summary>
        /// <returns>A string of two digits from 01 to 12.</returns>
        public static string GetRandomMonth()
        {
            char tensDigit = GrabRandomDigitStringFromSection(2);
            switch (tensDigit)
            {
                case '0':
                    return $"{tensDigit}{PreventZero()}";
                default:
                    return $"{tensDigit}{GrabRandomDigitStringFromSection(3)}";
            }
        }

        /// <summary>
        /// Generates a valid random day represented as two digits based on the month inputted.
        /// </summary>
        /// <param name="month">The random month generated.</param>
        /// <returns>A string of digits from 01 to 31, with a valid date based on the month inputted.</returns>
        public static string GetRandomDay(string month)
        {
            int numberMonth = Int32.Parse(month);

            if (numberMonth == 2)
                return HandleFeburuary();

            char tensDigit = GrabRandomDigitStringFromSection(4);

            if (tensDigit != '3')
                return HandleDatesBelowThirty(tensDigit);

            return $"{tensDigit}{HandleThirtyAndThrityFirstDate(numberMonth)}";
        }

        /// <summary>
        /// Generates a valid random day represented as two digits for months ending in either 30 or 31 days.
        /// </summary>
        /// <param name="numberMonth">The month represented as an integer.</param>
        /// <returns>A single character of '0' or '1' that is valid for the given month.</returns>
        private static char HandleThirtyAndThrityFirstDate(int numberMonth)
        {
            switch (numberMonth)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return GrabRandomDigitStringFromSection(2);
                default:
                    return '0';
            }
        }

        /// <summary>
        /// Generates a valid random day represented as two digits for any day from 01 to 29.
        /// </summary>
        /// <param name="tensDigit">The tens place digit for the date</param>
        /// <returns>A two digit string representing a valid date from 01 to 29.</returns>
        private static string HandleDatesBelowThirty(char tensDigit)
        {
            if (tensDigit != '0')
                return $"{tensDigit}{GrabRandomDigitCharacter}";
            else
                return $"{tensDigit}{PreventZero()}";
        }

        /// <summary>
        /// Generates a valid random day represented as two digits for the unique scenario of Feburuary on a leap year.
        /// </summary>
        /// <returns>A two digit string representing a valid date in Feburuary.</returns>
        private static string HandleFeburuary()
        {
            char tensDigit = GrabRandomDigitStringFromSection(3);
            return HandleDatesBelowThirty(tensDigit);
        }

        /// <summary>
        /// Generates a random digit character that is not zero.
        /// </summary>
        /// <returns>A single digit character this is not zero.</returns>
        private static char PreventZero()
        {
            char onesDigit;
            do
            {
                onesDigit = GrabRandomDigitCharacter;
            }
            while (onesDigit == '0');
            return onesDigit;
        }

        /// <summary>
        /// Converts the given string date that is expected to be in the format inputted to a format that the website returns as the date.
        /// </summary>
        /// <param name="date">The date inputted in the MM/DD/YYYY format.</param>
        /// <returns>A string that is the same date but is in the DD Month,YYYY format.</returns>
        public static string ConvertDateOfBirthFormat(string date)
        {

            string month = date.Substring(0, 2);
            string day = date.Substring(3, 2);
            string year = date.Substring(6);

            return $"{day} {ConvertMonthDigitsToWord(month)},{year}";
        }
    }
}