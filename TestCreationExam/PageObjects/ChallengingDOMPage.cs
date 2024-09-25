using OpenQA.Selenium;
using TestCreationExam.Common;
using TestCreationExam.PageObjects.Common;

namespace TestCreationExam.PageObjects
{
    public class ChallengingDOMPage : BasePageLocal
    {
        private readonly string _IpsumLocatorBuilder = "//tbody/tr/td[text()='Apeirian";
        private readonly string _AmetLocatorBuilder = "//tbody/tr/td[text()='Consequuntur";
        private readonly string _EndingLocatorBuilder = "']";

        public ChallengingDOMPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Locates a random row under Ipsum by building the locator within the method.
        /// </summary>
        /// <returns>The text from the randomly selected row in the Ipsum column.</returns>
        public string PullRandomIpsumRowData()
        {
            int columnIndex = Utils.Rnd.Next(9);
            return GetText(By.XPath($"{_IpsumLocatorBuilder}{columnIndex}{_EndingLocatorBuilder}"));
        }

        /// <summary>
        /// Locates the corresponding row under Amet that matches the row data inputted as the parameter,
        /// by building the locator within the method.
        /// </summary>
        /// <param name="searchIpsum">The data from the Ipsum column.</param>
        /// <returns>The data under Amet that is the same row as Ipsum.</returns>
        public string PullCorrespondingAmetRowData(string searchIpsum)
        {
            return GetText(By.XPath($"{_AmetLocatorBuilder}{searchIpsum.Substring(searchIpsum.Length-1)}{_EndingLocatorBuilder}"));
        }
    }
}