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
    }
}