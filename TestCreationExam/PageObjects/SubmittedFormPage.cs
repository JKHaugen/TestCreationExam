using OpenQA.Selenium;
using TestCreationExam.PageObjects.Common;

namespace TestCreationExam.PageObjects
{
    public class SubmittedFormPage : BasePageLocal
    {
        private readonly By _SubmittedStudentNameLocator = By.XPath("//td[text()='Student Name']/following-sibling::td");
        private readonly By _SubmittedStudentEmailLocator = By.XPath("//td[text()='Student Email']/following-sibling::td");
        private readonly By _SubmittedGenderLocator = By.XPath("//td[text()='Gender']/following-sibling::td");
        private readonly By _SubmittedMobileLocator = By.XPath("//td[text()='Mobile']/following-sibling::td");
        private readonly By _SubmittedDateOfBirthLocator = By.XPath("//td[text()='Date of Birth']/following-sibling::td");
        private readonly By _SubmittedHobbiesLocator = By.XPath("//td[text()='Hobbies']/following-sibling::td");
        private readonly By _SubmittedAddressLocator = By.XPath("//td[text()='Address']/following-sibling::td");
        private readonly By _SubmittedStateAndCityLocator = By.XPath("//td[text()='State and City']/following-sibling::td");

        public SubmittedFormPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Pulls the student's first and last name from the submitted form page.
        /// </summary>
        /// <returns>First and last name of the student.</returns>
        public string GetSubmittedStudentName()
        {
            return GetText(_SubmittedStudentNameLocator);
        }

        /// <summary>
        /// Pulls the student's email from the submitted form page.
        /// </summary>
        /// <returns>Email of the student.</returns>
        public string GetSubmittedStudentEmail()
        {
            return GetText(_SubmittedStudentEmailLocator);
        }

        /// <summary>
        /// Pulls the student's gender from the submitted form page.
        /// </summary>
        /// <returns>Gender of the student.</returns>
        public string GetSubmittedGender()
        {
            return GetText(_SubmittedGenderLocator);
        }

        /// <summary>
        /// Pulls the student's phone number from the submitted form page.
        /// </summary>
        /// <returns>Phone number of the student.</returns>
        public string GetSubmittedMobile()
        {
            return GetText(_SubmittedMobileLocator);
        }

        /// <summary>
        /// Pulls the student's date of birth from the submitted form page.
        /// </summary>
        /// <returns>Date of birth for the student.</returns>
        public string GetSubmittedDateOfBirth()
        {
            return GetText(_SubmittedDateOfBirthLocator);
        }

        /// <summary>
        /// Pulls the student's hobbies from the submitted form page.
        /// </summary>
        /// <returns>Hobbies of the student.</returns>
        public string GetSubmittedHobbies()
        {
            return GetText(_SubmittedHobbiesLocator);
        }

        /// <summary>
        /// Pulls the student's street address from the submitted form page.
        /// </summary>
        /// <returns>Street address of the student.</returns>
        public string GetSubmittedAddress()
        {
            return GetText(_SubmittedAddressLocator);
        }

        /// <summary>
        /// Pulls the student's state and city from the submitted form page.
        /// </summary>
        /// <returns>State and the city of the student.</returns>
        public string GetSubmittedStateAndCity()
        {
            return GetText(_SubmittedStateAndCityLocator);
        }
    }
}