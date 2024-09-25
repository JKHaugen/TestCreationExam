using OpenQA.Selenium;
using TestCreationExam.Common;
using TestCreationExam.PageObjects.Common;

namespace TestCreationExam.PageObjects
{
    public class StudentRegistrationFormPage : BasePageLocal
    {
        private readonly By _FirstNameFieldLocator = By.Id("firstName");
        private readonly By _LastNameFieldLocator = By.Id("lastName");
        private readonly By _EmailFieldLocator = By.Id("userEmail");
        private readonly By _MaleGenderLocator = By.CssSelector("label[for='gender-radio-1']");
        private readonly By _FemaleGenderLocator = By.CssSelector("label[for='gender-radio-2']");
        private readonly By _OtherGenderLocator = By.CssSelector("label[for='gender-radio-3']");
        private readonly By _MobilePhoneNumberLocator = By.Id("userNumber");
        private readonly By _DateOfBirthLocator = By.Id("dateOfBirthInput");
        private readonly By _SportsHobbyLocator = By.CssSelector("label[for='hobbies-checkbox-1']");
        private readonly By _ReadingHobbyLocator = By.CssSelector("label[for='hobbies-checkbox-2']");
        private readonly By _MusicHobbyLocator = By.CssSelector("label[for='hobbies-checkbox-3']");
        private readonly By _CurrentAddressLocator = By.Id("currentAddress");
        private readonly By _SelectStateDropdownLocator = By.XPath("//div[text()='Select State']");
        private readonly By _SelectCityDropdownLocator = By.XPath("//div[text()='Select City']");
        private readonly By _SelectNCRLocator = By.XPath("//div[text()='NCR']");
        private readonly By _SelectDelhiLocator = By.XPath("//div[text()='Delhi']");
        private readonly By _SubmitButtonLocator = By.Id("submit");

        public StudentRegistrationFormPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Creates a randomized first name of the given length that is inputted into the form.
        /// </summary>
        /// <param name="stringLength">Total number of characters to input.</param>
        /// <returns>Randomized first name of the given length.</returns>
        public string InputFirstName(int stringLength)
        {
            string firstName = Utils.GetRandomCharacterString(stringLength);
            EditBoxSendKeysAndVerify(_FirstNameFieldLocator, firstName);
            return firstName;
        }

        /// <summary>
        /// Creates a randomized last name of the given length that is inputted into the form.
        /// </summary>
        /// <param name="stringLength">Total number of characters to input.</param>
        /// <returns>Randomized last name of the given length.</returns>
        public string InputLastName(int stringLength)
        {
            string lastName = Utils.GetRandomCharacterString(stringLength);
            EditBoxSendKeysAndVerify(_LastNameFieldLocator, lastName);
            return lastName;
        }

        /// <summary>
        /// Takes the first name, last name, and the ending of the email and inputs into the form.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="atEmail"></param>
        /// <returns>The full email that was inputted.</returns>
        public string InputEmail(string firstName, string lastName, string atEmail)
        {
            string fullEmail = $"{firstName}{lastName}{atEmail}";
            EditBoxSendKeysAndVerify(_EmailFieldLocator, fullEmail);
            return fullEmail;
        }

        /// <summary>
        /// Randomly selects a gender on the form.
        /// </summary>
        /// <returns>The text of the selected gender.</returns>
        public string SelectRandomGender()
        {
            int randomValue = Utils.Rnd.Next(3);
            switch (randomValue)
            {
                case 0:
                    Click(_MaleGenderLocator);
                    return GetText(_MaleGenderLocator);
                case 1:
                    Click(_FemaleGenderLocator);
                    return GetText(_FemaleGenderLocator);
                default:
                    Click(_OtherGenderLocator);
                    return GetText(_OtherGenderLocator);
            }
        }

        /// <summary>
        /// Creates a random invalid phone number to be inputted into the form.
        /// </summary>
        /// <returns>The phone number inputted.</returns>
        public string InputRandomPhoneNumber()
        {
            string areaCode = Utils.GetRandomDigitString(3);
            string middleFives = "555";
            string lastFourDigits = Utils.GetRandomDigitString(4);
            string result = $"{areaCode}{middleFives}{lastFourDigits}";
            EditBoxSendKeysAndVerify(_MobilePhoneNumberLocator, result);
            return result;
        }

        /// <summary>
        /// Creates a valid date of birth for a person born in the year 2000 and inputs it into the form.
        /// </summary>
        /// <returns>The date of birth in the MM/DD/YYYY format that was inputted.</returns>
        public string InputDateOfBirth()
        {
            int timeout = 10;
            bool verifyInput = false;
            string month = Utils.GetRandomMonth();
            string day = Utils.GetRandomDay(month);
            string result = $"{month}/{day}/2000";
            EditBoxSendKeysAndVerify(_DateOfBirthLocator, result, timeout, verifyInput);
            DeleteFromBeginningOfTextField(_DateOfBirthLocator, 11);
            SendKeys(_DateOfBirthLocator, Keys.Enter);
            return result;
        }

        /// <summary>
        /// Randomly selects a hobby on the form.
        /// </summary>
        /// <returns>The text of the selected hobby.</returns>
        public string SelectRandomHobby()
        {
            int randomValue = Utils.Rnd.Next(3);
            switch (randomValue)
            {
                case 0:
                    Click(_SportsHobbyLocator);
                    return GetText(_SportsHobbyLocator);
                case 1:
                    Click(_ReadingHobbyLocator);
                    return GetText(_ReadingHobbyLocator);
                default:
                    Click(_MusicHobbyLocator);
                    return GetText(_MusicHobbyLocator);
            }
        }

        /// <summary>
        /// Creates a random street number on Main St that is inputted into the form.
        /// </summary>
        /// <param name="streetNumberDigitsCount">The total number of digits in the street number.</param>
        /// <returns>The whole street address inputted into the form.</returns>
        public string InputCurrentAddress(int streetNumberDigitsCount)
        {
            string streetNumber = Utils.GetRandomDigitString(streetNumberDigitsCount);
            string result = $"{streetNumber} Main St";
            EditBoxSendKeysAndVerify(_CurrentAddressLocator, result);
            return result;
        }

        /// <summary>
        /// Selects the NCR state from the dropdown.
        /// </summary>
        /// <returns>The selected state on the form.</returns>
        public string SelectStateDropdown()
        {
            Click(_SelectStateDropdownLocator);
            Click(_SelectNCRLocator);
            return GetText(_SelectNCRLocator);
        }

        /// <summary>
        /// Selects the Delhi City from the dropdown.
        /// </summary>
        /// <returns>The selected city on the form.</returns>
        public string SelectCityDropdown()
        {
            Click(_SelectCityDropdownLocator);
            Click(_SelectDelhiLocator);
            return GetText(_SelectDelhiLocator);
        }

        /// <summary>
        /// Selects the submit button on the form.
        /// </summary>
        public void SelectSubmitButton()
        {
            Click(_SubmitButtonLocator);
        }
    }
}