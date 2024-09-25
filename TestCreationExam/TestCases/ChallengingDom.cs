using NUnit.Framework;
using TestCreationExam.Common;
using TestCreationExam.PageObjects;
using TestCreationExam.TestCases.Common;

namespace TestCreationExam.TestCases
{
    class ChallengingDom : BaseTestLocal
    {
        [Test]
        [Category("Challenging DOM")]
        public void ChallengingDomCase()
        {
            string pulledIpsumData;
            string randomIpsumData;
            string pulledAmetData;
            char randomizedIpsumDataDigit;
            // Steps to automate:
            // 1. Navigate to https://the-internet.herokuapp.com/challenging_dom
            Driver.Value!.Url = "https://the-internet.herokuapp.com/challenging_dom";
            // 2. Randomly generate a cell value in the Ipsum column
            ChallengingDOMPage challengingDomPage = new ChallengingDOMPage(Driver.Value);
            pulledIpsumData = challengingDomPage.PullRandomIpsumRowData();
            randomIpsumData = Utils.ConvertToRandomRowData(pulledIpsumData);
            randomizedIpsumDataDigit = randomIpsumData.Last();
            // 3. Pass that value to a method in the page object that returns the corresponding value in the same
            //    row in the Amet column
            pulledAmetData = challengingDomPage.PullCorrespondingAmetRowData(randomIpsumData);
            // 4. Using NUnit asserts, assert that the returned value is correct
            Assert.AreEqual($"Consequuntur{randomizedIpsumDataDigit}", pulledAmetData);
            //
            // For example, if "Apeirian4" is generated from Ipsum, "Consequuntur4" would be returned from Amet
            // NOTE:
            // - Use the provided WebDriver methods in BasePageLocal
            // - Document all methods using XML documentation, https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/

        }
    }
}