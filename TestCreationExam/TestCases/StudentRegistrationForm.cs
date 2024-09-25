using NUnit.Framework;
using TestCreationExam.Common;
using TestCreationExam.PageObjects;
using TestCreationExam.TestCases.Common;

namespace TestCreationExam.TestCases
{
    class StudentRegistrationForm : BaseTestLocal
    {
        [Test]
        [Category("Student Registration Form")]
        public void StudentRegistrationFormCase()
        {
            int firstNameLength = 6;
            int lastNameLength = 8;
            string atEmail = "@example.com";
            int addressDigitsLength = 4;

            string generatedFirstName;
            string generatedLastName;
            string generatedEmail;
            string selectedGender;
            string generatedPhoneNumber;
            string generatedBirthday;
            string selectedHobby;
            string generatedAddress;
            string selectedState;
            string selectedCity;

            string submittedStudentName;
            string submittedStudentEmail;
            string submittedGender;
            string submittedPhoneNumber;
            string submittedBirthday;
            string submittedHobby;
            string submittedAddress;
            string submittedStateAndCity;
            // Steps to automate:
            // 1. Navigate to https://demoqa.com/automation-practice-form
            Driver.Value!.Url = "https://demoqa.com/automation-practice-form";
            // 2. Fill in first name with a random string [a-zA-Z] of length 6
            StudentRegistrationFormPage registrationFormPage = new StudentRegistrationFormPage(Driver.Value);
            generatedFirstName = registrationFormPage.InputFirstName(firstNameLength);
            // 3. Fill in last name with a random string [a-zA-Z] of length 8
            generatedLastName = registrationFormPage.InputLastName(lastNameLength);
            // 4. Fill in email, "<generated first name>.<generated last name>@example.com"
            generatedEmail = registrationFormPage.InputEmail(generatedFirstName, generatedLastName, atEmail);
            // 5. Randomly assign a gender from the three options
            selectedGender = registrationFormPage.SelectRandomGender();
            // 6. Fill in mobile using <3 random digits> + 555 + <4 random digits>
            generatedPhoneNumber = registrationFormPage.InputRandomPhoneNumber();
            // 7. Fill in date of birth with a random day/month in 2000
            generatedBirthday = registrationFormPage.InputDateOfBirth();
            // 8. Select one of the three hobbies at random
            selectedHobby = registrationFormPage.SelectRandomHobby();
            // 9. Set the current address to, "<4 random digits> Main St"
            generatedAddress = registrationFormPage.InputCurrentAddress(addressDigitsLength);
            // 10. Set the state to "NCR"
            selectedState = registrationFormPage.SelectStateDropdown();
            // 11. Set the city to "Delhi"
            selectedCity = registrationFormPage.SelectCityDropdown();
            // 12. Click Submit
            registrationFormPage.SelectSubmitButton();
            // 13. Using NUnit asserts, assert each of the form submission results against what was entered
            SubmittedFormPage submittedFormPage = new SubmittedFormPage(Driver.Value);
            submittedStudentName = submittedFormPage.GetSubmittedStudentName();
            submittedStudentEmail = submittedFormPage.GetSubmittedStudentEmail();
            submittedGender = submittedFormPage.GetSubmittedGender();
            submittedPhoneNumber = submittedFormPage.GetSubmittedMobile();
            submittedBirthday = submittedFormPage.GetSubmittedDateOfBirth();
            submittedHobby = submittedFormPage.GetSubmittedHobbies();
            submittedAddress = submittedFormPage.GetSubmittedAddress();
            submittedStateAndCity = submittedFormPage.GetSubmittedStateAndCity();

            Assert.AreEqual($"{generatedFirstName} {generatedLastName}", submittedStudentName);
            Assert.AreEqual(generatedEmail, submittedStudentEmail);
            Assert.AreEqual(selectedGender, submittedGender);
            Assert.AreEqual(generatedPhoneNumber, submittedPhoneNumber);
            Assert.AreEqual(Utils.ConvertDateOfBirthFormat(generatedBirthday), submittedBirthday);
            Assert.AreEqual(selectedHobby, submittedHobby);
            Assert.AreEqual(generatedAddress, submittedAddress);
            Assert.AreEqual($"{selectedState} {selectedCity}", submittedStateAndCity);
            //
            // NOTE:
            // - Use the provided WebDriver methods in BasePageLocal
            // - Document all methods using XML documentation, https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/
        }
    }
}